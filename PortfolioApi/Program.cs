using System.Text.Json;
using PortfolioApi;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers()
    .AddJsonOptions(x =>
    {
        x.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.SnakeCaseLower;
        x.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.SnakeCaseLower;
    });

builder.Services.AddUrlVersioning();
builder.Services.AddFluentMigration();
builder.Services.AddHealthChecks();

var app = builder.Build();

// note:
// - we will show the api documentation even in production
app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();
app.MapHealthChecks("/heath_checks");
app.MapControllers();

app.Run();