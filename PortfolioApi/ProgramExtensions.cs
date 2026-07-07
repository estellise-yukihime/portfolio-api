using Asp.Versioning;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.Sqlite;
using Microsoft.IdentityModel.Tokens;
using PortfolioApi.ExternalServices.Persistence;
using PortfolioApi.ExternalServices.Persistence.Sqlite;

namespace PortfolioApi;

public static class ProgramExtensions
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddUrlVersioning()
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

        // note:
        //  we are using FluentMigrator as a migration tool to generate our database
        public IServiceCollection AddFluentMigration()
        {
            services.AddFluentMigratorCore()
                .ConfigureRunner(x =>
                {
                    x.AddSQLite()
                        .WithGlobalConnectionString("Data Source=main.db")
                        .ScanIn(typeof(Program).Assembly).For.Migrations();
                })
                .AddLogging(x => x.AddFluentMigratorConsole());

            return services;
        }

        public IServiceCollection AddSqlDb()
        {
            services.AddSingleton<IDbConnection<SqliteConnection>, SqliteConnectionSource>();

            return services;
        }
    }
}