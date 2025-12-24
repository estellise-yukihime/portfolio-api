using System.Text.Json;
using Asp.Versioning;
using PortfolioApi;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(x =>
    {
        x.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "portfolio",
            ValidAudience = "portfolio-app",
            IssuerSigningKey = new SymmetricSecurityKey("portfolio"u8.ToArray())
        };
    });

builder.Services.AddApiVersioning(x =>
{
    x.DefaultApiVersion = new ApiVersion(1);
    x.ReportApiVersions = true;
    x.AssumeDefaultVersionWhenUnspecified = true;
    x.ApiVersionReader = new UrlSegmentApiVersionReader();
}).AddApiExplorer(x =>
{
    x.GroupNameFormat = "'v'V";
    x.DefaultApiVersion = new ApiVersion(1);
    x.ApiVersionParameterSource = new UrlSegmentApiVersionReader();
    x.AssumeDefaultVersionWhenUnspecified = true;
});

builder.Services.AddHealthChecks();

builder.Services.AddFluentMigration();

var app = builder.Build();

// note:
// - we will show the api documentation even in production
app.MapOpenApi();
app.MapScalarApiReference();

app.UseHttpsRedirection();
app.MapHealthChecks("/heath_checks");
app.MapControllers();

app.Run();