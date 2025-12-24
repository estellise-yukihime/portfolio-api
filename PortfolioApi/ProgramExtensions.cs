using FluentMigrator.Runner;
using Microsoft.Data.Sqlite;
using PortfolioApi.ExternalServices.Persistence;
using PortfolioApi.ExternalServices.Persistence.Sqlite;

namespace PortfolioApi;

public static class ProgramExtensions
{
    extension(IServiceCollection services)
    {
    
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