using Asp.Versioning;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpLogging;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Logging.Console;
using Microsoft.IdentityModel.Tokens;
using PortfolioApi.ExternalServices.Persistence;
using PortfolioApi.ExternalServices.Persistence.Sqlite;

namespace PortfolioApi;

public static class ProgramExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddSimpleLogging()
        {
            services.AddLogging(x =>
            {
                x.AddSimpleConsole(c =>
                {
                    c.IncludeScopes = true;
                    c.TimestampFormat = "yyyy-MM-dd HH:mm:ss ";
                    c.ColorBehavior = LoggerColorBehavior.Enabled;
                });
            });

            services.AddHttpLogging(x =>
            {
                x.LoggingFields = HttpLoggingFields.Duration
                                  | HttpLoggingFields.Request
                                  | HttpLoggingFields.RequestQuery
                                  | HttpLoggingFields.Response;
                x.RequestBodyLogLimit = 8192;
                x.ResponseBodyLogLimit = 8192;
            });

            return services;
        }

        public IServiceCollection AddSimpleVersioning()
        {
            services.AddApiVersioning(x =>
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

            return services;
        }

        public IServiceCollection AddAuth()
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
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

            return services;
        }

        public IServiceCollection AddFluentMigration()
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(x =>
                {
                    x.AddSQLite(compatibilityMode: CompatibilityMode.LOOSE)
                        .WithGlobalConnectionString("Data Source=data/main.db")
                        .ScanIn(typeof(Program).Assembly).For.Migrations();
                });

            return services;
        }

        public IServiceCollection AddSqlDb()
        {
            services.AddSingleton<IDbConnection<SqliteConnection>, SqliteConnectionSource>();

            return services;
        }
    }
}