using FluentMigrator.Runner;

namespace PortfolioApi.Migrations;

public class ProcMigration : BackgroundService
{
    private readonly IMigrationRunner _migrationRunner;

    public ProcMigration(IMigrationRunner migrationRunner)
    {
        _migrationRunner = migrationRunner;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _migrationRunner.MigrateUp();

        return Task.CompletedTask;
    }
}