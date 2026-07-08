using System.Text.Json;
using PortfolioApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        x.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower;
    });

builder.Services.AddCors(x =>
{
    x.AddDefaultPolicy(c =>
    {
        // c.WithOrigins(builder.Configuration.GetSection("Cors:Origins").Get<string[]>()!)
        //     .AllowAnyHeader()
        //     .AllowAnyMethod();

        c.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});
builder.Services.AddSimpleLogging();
builder.Services.AddSimpleVersioning();
builder.Services.AddFluentMigration();
builder.Services.AddSqlDb();
builder.Services.AddDefaultServices();
builder.Services.AddExternalServicesPersistence();

// health checks
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseHttpLogging();
app.UseHttpsRedirection();
app.UseCors();

// note:
// - we will show the api documentation even in production
app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();
app.MapHealthChecks("/health_checks");

app.Run();