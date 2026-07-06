using Microsoft.Data.SqlClient;

public class OfflineQueueWorker : BackgroundService
{
    private readonly string _connectionString;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<OfflineQueueWorker> _logger;

    public OfflineQueueWorker(
        string connectionString,
        IHttpClientFactory httpClientFactory,
        ILogger<OfflineQueueWorker> logger)
    {
        _connectionString = connectionString;
        _httpClientFactory = httpClientFactory;
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("OfflineQueueWorker iniciado — revisando cada 30 segundos");
        while (!stoppingToken.IsCancellationRequested)
        {
            await ProcesarColaAsync();
            await Task.Delay(TimeSpan.FromSeconds(30), stoppingToken);
        }
    }

    private async Task ProcesarColaAsync()
    {
        try
        {
            var client = _httpClientFactory.CreateClient("CoreApi");
            try
            {
                var health = await client.GetAsync("/health");
                if (!health.IsSuccessStatusCode)
                {
                    _logger.LogWarning("Core no disponible. Cola en espera.");
                    return;
                }
            }
            catch
            {
                _logger.LogWarning("Core no responde. Cola en espera.");
                return;
            }

            using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var selectCmd = new SqlCommand(@"
                SELECT id, payload_json, endpoint_destino, metodo_http
                FROM OfflineQueue
                WHERE procesado = 0
                ORDER BY timestamp_recibido ASC", connection);

            var pendientes = new List<(Guid id, string payload, string endpoint, string metodo)>();
            using (var reader = await selectCmd.ExecuteReaderAsync())
            {
                while (await reader.ReadAsync())
                    pendientes.Add((
                        reader.GetGuid(0),
                        reader.GetString(1),
                        reader.GetString(2),
                        reader.GetString(3)));
            }

            if (pendientes.Count == 0) return;

            foreach (var (id, payload, endpoint, metodo) in pendientes)
            {
                try
                {
                    var request = new HttpRequestMessage
                    {
                        Method = new HttpMethod(metodo),
                        RequestUri = new Uri(endpoint, UriKind.Relative),
                        Content = new StringContent(payload,
                            System.Text.Encoding.UTF8, "application/json")
                    };

                    var response = await client.SendAsync(request);

                    if (response.IsSuccessStatusCode)
                    {
                        var updateCmd = new SqlCommand(@"
                            UPDATE OfflineQueue
                            SET procesado = 1, timestamp_procesado = GETUTCDATE()
                            WHERE id = @id", connection);
                        updateCmd.Parameters.AddWithValue("@id", id);
                        await updateCmd.ExecuteNonQueryAsync();
                        _logger.LogInformation($"Peticion {id} procesada exitosamente.");
                    }
                    else
                    {
                        var errorMsg = await response.Content.ReadAsStringAsync();
                        var errorCmd = new SqlCommand(@"
                            UPDATE OfflineQueue SET error_detalle = @error WHERE id = @id",
                            connection);
                        errorCmd.Parameters.AddWithValue("@id", id);
                        errorCmd.Parameters.AddWithValue("@error",
                            $"HTTP {(int)response.StatusCode}: {errorMsg}");
                        await errorCmd.ExecuteNonQueryAsync();
                        _logger.LogWarning($"Peticion {id} rechazada por el Core.");
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error al procesar {id}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            _logger.LogError($"Error general en worker: {ex.Message}");
        }
    }
}
