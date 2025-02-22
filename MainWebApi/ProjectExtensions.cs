using FluentMigrator.Runner;
using MainWebApi.ExternalServices.Persistence;
using Microsoft.Data.Sqlite;

namespace MainWebApi;

public static class ProjectExtensions
{
    public static IServiceCollection AddFluentMigration(this IServiceCollection services)
    {
        services.AddFluentMigratorCore()
            .ConfigureRunner(x =>
            {
                x.AddSQLite()
                    .WithGlobalConnectionString(@"Data Source=:memory:")
                    .ScanIn(typeof(Program).Assembly).For.Migrations();
            })
            .AddLogging(x => x.AddFluentMigratorConsole());

        return services;
    }

    public static IServiceCollection AddSqlDb(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnection<SqliteConnection>, SqliteConnectionSource>();

        return services;
    }
}