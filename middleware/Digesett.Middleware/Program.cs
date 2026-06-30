using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpClient("CoreApi", client =>
{
    client.BaseAddress = new Uri(builder.Configuration["CoreApi:BaseUrl"]!);
    client.Timeout = TimeSpan.FromSeconds(10);
});

var jwtSecret = builder.Configuration["Jwt:SecretKey"]!;
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
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(jwtSecret))
        };
    });

builder.Services.AddAuthorization();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();

string connectionString = builder.Configuration
    .GetConnectionString("DigesettMiddleware")!;

var random = new Random();

// MOCK JCE
app.MapGet("/api/mock/jce/cedula/{id}", async (string id) =>
{
    if (random.Next(1, 101) <= 5)
        return Results.Json(
            new { mensaje = "Servicio no disponible temporalmente", retry_after_seconds = 30 },
            statusCode: 503);

    using var connection = new SqlConnection(connectionString);
    await connection.OpenAsync();

    var command = new SqlCommand(
        "SELECT cedula, nombre_completo, estado FROM MockConductores WHERE cedula = @cedula",
        connection);
    command.Parameters.AddWithValue("@cedula", id);

    using var reader = await command.ExecuteReaderAsync();

    if (await reader.ReadAsync())
        return Results.Ok(new
        {
            cedula = reader.GetString(0),
            nombre_completo = reader.GetString(1),
            estado = reader.GetString(2)
        });

    return Results.NotFound(new { mensaje = "Cédula no encontrada" });
});

// MOCK DGII
app.MapGet("/api/mock/dgii/placa/{placa}", async (string placa) =>
{
    if (random.Next(1, 101) <= 5)
        return Results.Json(
            new { mensaje = "Servicio no disponible temporalmente", retry_after_seconds = 30 },
            statusCode: 503);

    using var connection = new SqlConnection(connectionString);
    await connection.OpenAsync();

    var command = new SqlCommand(
        "SELECT placa, marca, modelo, propietario_cedula, marbete_vigente FROM MockVehiculos WHERE placa = @placa",
        connection);
    command.Parameters.AddWithValue("@placa", placa);

    using var reader = await command.ExecuteReaderAsync();

    if (await reader.ReadAsync())
        return Results.Ok(new
        {
            placa = reader.GetString(0),
            marca = reader.GetString(1),
            modelo = reader.GetString(2),
            propietario_cedula = reader.GetString(3),
            marbete_vigente = reader.GetBoolean(4)
        });

    return Results.NotFound(new { mensaje = "Placa no encontrada" });
});

// PROXY INVERSO hacia el Core de Antony
app.Map("/api/v1/{**ruta}", async (
    HttpContext context,
    IHttpClientFactory httpClientFactory,
    string ruta) =>
{
    if (!context.User.Identity?.IsAuthenticated ?? true)
        return Results.Json(
            new { mensaje = "Token JWT requerido o inválido" },
            statusCode: 401);

    var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value
              ?? context.User.FindFirst("sub")?.Value
              ?? "desconocido";

    var userRole = context.User.FindFirst(ClaimTypes.Role)?.Value
                ?? context.User.FindFirst("role")?.Value
                ?? "desconocido";

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

    if (context.Request.ContentLength > 0)
    {
        requestMessage.Content = new StreamContent(context.Request.Body);
        if (context.Request.ContentType != null)
            requestMessage.Content.Headers.ContentType =
                new System.Net.Http.Headers.MediaTypeHeaderValue(
                    context.Request.ContentType);
    }

    try
    {
        var response = await client.SendAsync(requestMessage);
        var contenido = await response.Content.ReadAsStringAsync();
        return Results.Content(contenido,
            contentType: "application/json",
            statusCode: (int)response.StatusCode);
    }
    catch (HttpRequestException)
    {
        return Results.Json(
            new { mensaje = "El Core no está disponible en este momento" },
            statusCode: 503);
    }
});

app.Run();