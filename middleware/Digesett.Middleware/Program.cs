using Microsoft.Data.SqlClient;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Leemos la cadena de conexión que configuramos en appsettings.Development.json
string connectionString = builder.Configuration.GetConnectionString("DigesettMiddleware")!;

// Un solo "generador de números al azar" para usar en ambos endpoints
var random = new Random();

// ===========================================
// MOCK JCE - Consulta por cédula
// ===========================================
app.MapGet("/api/mock/jce/cedula/{id}", async (string id) =>
{
    // 5% de las peticiones fallan a propósito (simulando que el "gobierno" no responde)
    if (random.Next(1, 101) <= 5)
    {
        return Results.Json(
            new { mensaje = "Servicio no disponible temporalmente", retry_after_seconds = 30 },
            statusCode: 503);
    }

    using var connection = new SqlConnection(connectionString);
    await connection.OpenAsync();

    var command = new SqlCommand(
        "SELECT cedula, nombre_completo, estado FROM MockConductores WHERE cedula = @cedula",
        connection);
    command.Parameters.AddWithValue("@cedula", id);

    using var reader = await command.ExecuteReaderAsync();

    if (await reader.ReadAsync())
    {
        return Results.Ok(new
        {
            cedula = reader.GetString(0),
            nombre_completo = reader.GetString(1),
            estado = reader.GetString(2)
        });
    }

    return Results.NotFound(new { mensaje = "Cédula no encontrada en el sistema mock de la JCE" });
});

// ===========================================
// MOCK DGII - Consulta por placa
// ===========================================
app.MapGet("/api/mock/dgii/placa/{placa}", async (string placa) =>
{
    if (random.Next(1, 101) <= 5)
    {
        return Results.Json(
            new { mensaje = "Servicio no disponible temporalmente", retry_after_seconds = 30 },
            statusCode: 503);
    }

    using var connection = new SqlConnection(connectionString);
    await connection.OpenAsync();

    var command = new SqlCommand(
        "SELECT placa, marca, modelo, propietario_cedula, marbete_vigente FROM MockVehiculos WHERE placa = @placa",
        connection);
    command.Parameters.AddWithValue("@placa", placa);

    using var reader = await command.ExecuteReaderAsync();

    if (await reader.ReadAsync())
    {
        return Results.Ok(new
        {
            placa = reader.GetString(0),
            marca = reader.GetString(1),
            modelo = reader.GetString(2),
            propietario_cedula = reader.GetString(3),
            marbete_vigente = reader.GetBoolean(4)
        });
    }

    return Results.NotFound(new { mensaje = "Placa no encontrada en el sistema mock de la DGII" });
});

app.Run();