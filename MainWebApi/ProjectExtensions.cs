using FluentMigrator.Runner;

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
}