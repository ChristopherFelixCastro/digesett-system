using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Data.SqlClient;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json;
using AspNetCoreRateLimit;
using System.Threading.Tasks;
using System;
using System.Net.Http;
using System.Security.Claims;
using System.IO;

var builder = WebApplication.CreateBuilder(args);

// TAREA 1.D: PII LOGGING
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddProvider(new PiiSanitizingLoggerProvider());

// TAREA 1.C: RATE LIMITING
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(builder.Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(builder.Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.AddInMemoryRateLimiting();
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var jwtSecret = builder.Configuration["Jwt:SecretKey"] ?? "clave-temporal-desarrollo-digesett-middleware-2024";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSecret))
        };
    });
builder.Services.AddAuthorization();

builder.Services.AddHttpClient("CoreApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CoreApi:BaseUrl"] ?? "http://localhost:5001");
    client.Timeout = TimeSpan.FromSeconds(10);
});

builder.Services.AddHostedService(provider => new OfflineQueueWorker(
    builder.Configuration.GetConnectionString("DigesettMiddleware")!,
    provider.GetRequiredService<IHttpClientFactory>(),
    provider.GetRequiredService<ILogger<OfflineQueueWorker>>()
));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Middleware — Endpoints del codigo");
        c.SwaggerEndpoint("/openapi-completo", "DIGESETT API Completa — Todos los endpoints");
        c.RoutePrefix = "swagger";
    });
}

app.MapGet("/openapi-completo", async context =>
{
    var ruta = @"C:\Demo Middleware\middleware Demo01\openapi.yaml";
    if (File.Exists(ruta))
    {
        context.Response.ContentType = "application/yaml";
        await context.Response.WriteAsync(await File.ReadAllTextAsync(ruta));
    }
    else
    {
        context.Response.StatusCode = 404;
        await context.Response.WriteAsync("openapi.yaml no encontrado en: " + ruta);
    }
});

app.UseAuthentication();
app.UseAuthorization();

// TAREA 1.C: RATE LIMITING
app.UseIpRateLimiting();

string connectionString = builder.Configuration.GetConnectionString("DigesettMiddleware")!;
var random = new Random();

// MOCK JCE
app.MapGet("/api/mock/jce/cedula/{id}", async (string id) =>
{
    if (random.Next(1, 101) <= 5) return Results.Json(new { mensaje = "Servicio no disponible temporalmente", retry_after_seconds = 30 }, statusCode: 503);

    var cacheKey = $"jce_{id}";
    using var conn = new SqlConnection(connectionString);
    await conn.OpenAsync();

    using var cmdCache = new SqlCommand("SELECT response_json FROM CacheConsultas WHERE cache_key = @key AND expira_en > GETUTCDATE()", conn);
    cmdCache.Parameters.AddWithValue("@key", cacheKey);
    var cached = await cmdCache.ExecuteScalarAsync();
    if (cached != null) return Results.Content(cached.ToString()!, "application/json");

    using var cmd = new SqlCommand("SELECT cedula, nombre_completo, estado FROM MockConductores WHERE cedula = @cedula", conn);
    cmd.Parameters.AddWithValue("@cedula", id);
    using var reader = await cmd.ExecuteReaderAsync();

    if (await reader.ReadAsync())
    {
        var responseObj = new
        {
            cedula = reader.GetString(0),
            nombre_completo = reader.GetString(1),
            estado = reader.GetString(2)
        };
        var responseJson = JsonSerializer.Serialize(responseObj);
        await reader.CloseAsync();

        using var cmdUpsert = new SqlCommand(@"MERGE CacheConsultas AS target
            USING (SELECT @key AS cache_key) AS source ON target.cache_key = source.cache_key
            WHEN MATCHED THEN UPDATE SET response_json = @json, expira_en = DATEADD(MINUTE, 15, GETUTCDATE())
            WHEN NOT MATCHED THEN INSERT (cache_key, response_json, expira_en) VALUES (@key, @json, DATEADD(MINUTE, 15, GETUTCDATE()));", conn);
        cmdUpsert.Parameters.AddWithValue("@key", cacheKey);
        cmdUpsert.Parameters.AddWithValue("@json", responseJson);
        await cmdUpsert.ExecuteNonQueryAsync();

        return Results.Ok(responseObj);
    }
    return Results.NotFound(new { mensaje = "Cédula no encontrada" });
});

// MOCK DGII
app.MapGet("/api/mock/dgii/placa/{placa}", async (string placa) =>
{
    if (random.Next(1, 101) <= 5) return Results.Json(new { mensaje = "Servicio no disponible temporalmente", retry_after_seconds = 30 }, statusCode: 503);

    var cacheKey = $"dgii_{placa}";
    using var conn = new SqlConnection(connectionString);
    await conn.OpenAsync();

    using var cmdCache = new SqlCommand("SELECT response_json FROM CacheConsultas WHERE cache_key = @key AND expira_en > GETUTCDATE()", conn);
    cmdCache.Parameters.AddWithValue("@key", cacheKey);
    var cached = await cmdCache.ExecuteScalarAsync();
    if (cached != null) return Results.Content(cached.ToString()!, "application/json");

    using var cmd = new SqlCommand("SELECT placa, marca, modelo, propietario_cedula, marbete_vigente FROM MockVehiculos WHERE placa = @placa", conn);
    cmd.Parameters.AddWithValue("@placa", placa);
    using var reader = await cmd.ExecuteReaderAsync();

    if (await reader.ReadAsync())
    {
        var responseObj = new
        {
            placa = reader.GetString(0),
            marca = reader.GetString(1),
            modelo = reader.GetString(2),
            propietario_cedula = reader.GetString(3),
            marbete_vigente = reader.GetBoolean(4)
        };
        var responseJson = JsonSerializer.Serialize(responseObj);
        await reader.CloseAsync();

        using var cmdUpsert = new SqlCommand(@"MERGE CacheConsultas AS target
            USING (SELECT @key AS cache_key) AS source ON target.cache_key = source.cache_key
            WHEN MATCHED THEN UPDATE SET response_json = @json, expira_en = DATEADD(MINUTE, 15, GETUTCDATE())
            WHEN NOT MATCHED THEN INSERT (cache_key, response_json, expira_en) VALUES (@key, @json, DATEADD(MINUTE, 15, GETUTCDATE()));", conn);
        cmdUpsert.Parameters.AddWithValue("@key", cacheKey);
        cmdUpsert.Parameters.AddWithValue("@json", responseJson);
        await cmdUpsert.ExecuteNonQueryAsync();

        return Results.Ok(responseObj);
    }
    return Results.NotFound(new { mensaje = "Placa no encontrada" });
});

// MOCK PGR
app.MapGet("/api/mock/pgr/antecedentes/{cedula}", async (string cedula) =>
{
    if (random.Next(1, 101) <= 5) return Results.Json(new { mensaje = "Servicio no disponible temporalmente", retry_after_seconds = 30 }, statusCode: 503);

    var cacheKey = $"pgr_{cedula}";
    using var conn = new SqlConnection(connectionString);
    await conn.OpenAsync();

    using var cmdCache = new SqlCommand("SELECT response_json FROM CacheConsultas WHERE cache_key = @key AND expira_en > GETUTCDATE()", conn);
    cmdCache.Parameters.AddWithValue("@key", cacheKey);
    var cached = await cmdCache.ExecuteScalarAsync();
    if (cached != null) return Results.Content(cached.ToString()!, "application/json");

    using var cmd = new SqlCommand("SELECT cedula, nombre_completo, estado FROM MockConductores WHERE cedula = @cedula", conn);
    cmd.Parameters.AddWithValue("@cedula", cedula);
    using var reader = await cmd.ExecuteReaderAsync();

    if (await reader.ReadAsync())
    {
        var estadoConductor = reader.GetString(2);
        var tieneAntecedentes = estadoConductor == "SUSPENDIDO";
        var responseObj = new
        {
            cedula = reader.GetString(0),
            nombre_completo = reader.GetString(1),
            tiene_antecedentes = tieneAntecedentes,
            detalle = tieneAntecedentes ? "Registro encontrado en el sistema de antecedentes penales" : "Sin antecedentes penales registrados"
        };
        var responseJson = JsonSerializer.Serialize(responseObj);
        await reader.CloseAsync();

        using var cmdUpsert = new SqlCommand(@"MERGE CacheConsultas AS target
            USING (SELECT @key AS cache_key) AS source ON target.cache_key = source.cache_key
            WHEN MATCHED THEN UPDATE SET response_json = @json, expira_en = DATEADD(MINUTE, 15, GETUTCDATE())
            WHEN NOT MATCHED THEN INSERT (cache_key, response_json, expira_en) VALUES (@key, @json, DATEADD(MINUTE, 15, GETUTCDATE()));", conn);
        cmdUpsert.Parameters.AddWithValue("@key", cacheKey);
        cmdUpsert.Parameters.AddWithValue("@json", responseJson);
        await cmdUpsert.ExecuteNonQueryAsync();

        return Results.Ok(responseObj);
    }
    return Results.NotFound(new { mensaje = "Cédula no encontrada en el sistema mock de la PGR" });
});

// MOCK INTRANT
app.MapGet("/api/mock/intrant/licencia/{cedula}", async (string cedula) =>
{
    if (random.Next(1, 101) <= 5) return Results.Json(new { mensaje = "Servicio no disponible temporalmente", retry_after_seconds = 30 }, statusCode: 503);

    var cacheKey = $"intrant_{cedula}";
    using var conn = new SqlConnection(connectionString);
    await conn.OpenAsync();

    using var cmdCache = new SqlCommand("SELECT response_json FROM CacheConsultas WHERE cache_key = @key AND expira_en > GETUTCDATE()", conn);
    cmdCache.Parameters.AddWithValue("@key", cacheKey);
    var cached = await cmdCache.ExecuteScalarAsync();
    if (cached != null) return Results.Content(cached.ToString()!, "application/json");

    using var cmd = new SqlCommand("SELECT cedula, numero_licencia, categoria, vigente, renovacion_bloqueada FROM MockLicencias WHERE cedula = @cedula", conn);
    cmd.Parameters.AddWithValue("@cedula", cedula);
    using var reader = await cmd.ExecuteReaderAsync();

    if (await reader.ReadAsync())
    {
        var responseObj = new
        {
            cedula = reader.GetString(0),
            numero_licencia = reader.GetString(1),
            categoria = reader.GetString(2),
            vigente = reader.GetBoolean(3),
            licencia_bloqueada = reader.GetBoolean(4)
        };
        var responseJson = JsonSerializer.Serialize(responseObj);
        await reader.CloseAsync();

        using var cmdUpsert = new SqlCommand(@"MERGE CacheConsultas AS target
            USING (SELECT @key AS cache_key) AS source ON target.cache_key = source.cache_key
            WHEN MATCHED THEN UPDATE SET response_json = @json, expira_en = DATEADD(MINUTE, 15, GETUTCDATE())
            WHEN NOT MATCHED THEN INSERT (cache_key, response_json, expira_en) VALUES (@key, @json, DATEADD(MINUTE, 15, GETUTCDATE()));", conn);
        cmdUpsert.Parameters.AddWithValue("@key", cacheKey);
        cmdUpsert.Parameters.AddWithValue("@json", responseJson);
        await cmdUpsert.ExecuteNonQueryAsync();

        return Results.Ok(responseObj);
    }
    return Results.NotFound(new { mensaje = "Cédula no encontrada en el sistema mock del INTRANT" });
});

// TAREA 1.B: ENDPOINT DE PAGO
app.MapPost("/pagos/procesar", async (PagoRequest request, IHttpClientFactory httpClientFactory) =>
{
    if (string.IsNullOrWhiteSpace(request.acta_uuid)) return Results.BadRequest(new { error = "acta_uuid es requerido" });
    if (request.numero_tarjeta?.Length != 16 || !System.Text.RegularExpressions.Regex.IsMatch(request.numero_tarjeta, @"^\d{16}$")) return Results.BadRequest(new { error = "Numero de tarjeta invalido" });
    if (request.cvv?.Length != 3 || !System.Text.RegularExpressions.Regex.IsMatch(request.cvv, @"^\d{3}$")) return Results.BadRequest(new { error = "CVV invalido" });

    var numeroTransaccion = Guid.NewGuid().ToString();
    var montoTotal = request.monto_multa + request.monto_recargo;

    try
    {
        var client = httpClientFactory.CreateClient("CoreApi");
        var payload = new { numero_transaccion = numeroTransaccion, monto_total = montoTotal };
        var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
        await client.PostAsync($"/api/v1/actas/{request.acta_uuid}/pagar", content);
    }
    catch
    {
        // Ignorar silenciosamente si el Core falla
    }

    return Results.Ok(new
    {
        numero_transaccion = numeroTransaccion,
        acta_uuid = request.acta_uuid,
        monto_total = montoTotal,
        estado = "PAGADA",
        fecha_pago = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ")
    });
});

// PROXY INVERSO hacia el Core
app.Map("/api/v1/{**ruta}", async (HttpContext context, IHttpClientFactory httpClientFactory, string ruta) =>
{
    if (!context.User.Identity?.IsAuthenticated ?? true)
        return Results.Json(new { mensaje = "Token JWT requerido o inválido" }, statusCode: 401);

    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? context.User.FindFirst("sub")?.Value ?? "desconocido";
    var userRole = context.User.FindFirst(ClaimTypes.Role)?.Value ?? context.User.FindFirst("role")?.Value ?? "desconocido";

    var queryString = context.Request.QueryString.Value ?? "";
    var urlDestino = $"/api/v1/{ruta}{queryString}";

    var client = httpClientFactory.CreateClient("CoreApi");
    var requestMessage = new HttpRequestMessage
    {
        Method = new HttpMethod(context.Request.Method),
        RequestUri = new Uri(urlDestino, UriKind.Relative)
    };

    requestMessage.Headers.Add("X-User-Id", userId);
    requestMessage.Headers.Add("X-User-Role", userRole);

    string payloadJson = "";
    if (context.Request.ContentLength > 0)
    {
        using var reader = new StreamReader(context.Request.Body);
        payloadJson = await reader.ReadToEndAsync();
        requestMessage.Content = new StringContent(payloadJson, Encoding.UTF8, context.Request.ContentType ?? "application/json");
    }

    try
    {
        var response = await client.SendAsync(requestMessage);
        var contenido = await response.Content.ReadAsStringAsync();
        return Results.Content(contenido, contentType: "application/json", statusCode: (int)response.StatusCode);
    }
    catch (HttpRequestException)
    {
        var method = context.Request.Method;
        if (method == "POST" || method == "PUT" || method == "PATCH")
        {
            var queueId = Guid.NewGuid();
            using var conn = new SqlConnection(connectionString);
            await conn.OpenAsync();
            using var cmd = new SqlCommand("INSERT INTO OfflineQueue (id, payload_json, endpoint_destino, metodo_http, timestamp_recibido, procesado) VALUES (@id, @payload, @endpoint, @metodo, @timestamp, 0)", conn);
            cmd.Parameters.AddWithValue("@id", queueId);
            cmd.Parameters.AddWithValue("@payload", payloadJson);
            cmd.Parameters.AddWithValue("@endpoint", $"/api/v1/{ruta}");
            cmd.Parameters.AddWithValue("@metodo", method);
            cmd.Parameters.AddWithValue("@timestamp", DateTime.UtcNow);
            await cmd.ExecuteNonQueryAsync();

            return Results.Json(new { mensaje = "Guardado offline", queue_id = queueId }, statusCode: 202);
        }

        return Results.Json(new { mensaje = "El Core no está disponible en este momento" }, statusCode: 503);
    }
});

app.Run();

record PagoRequest(string acta_uuid, decimal monto_multa, decimal monto_recargo, string numero_tarjeta, string nombre_titular, string cvv, string fecha_vencimiento);
