using Asp.Versioning;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Controllers.Super.Migration;

[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}/super/migrations")]
public class MigrationsController : ControllerBase
{
    private readonly IMigrationRunner _migrationRunner;

    public MigrationsController(IMigrationRunner migrationRunner)
    {
        _migrationRunner = migrationRunner;
    }

    [HttpPost("up")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Up()
    {
        _migrationRunner.MigrateUp();

        return Ok();
    }

    [HttpPost("down/{revision:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult Down(long revision)
    {
        _migrationRunner.MigrateDown(revision);

        return Ok();
    }

    [HttpPost("rollback-revision/{revision:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RollbackRevision(long revision)
    {
        _migrationRunner.RollbackToVersion(revision);

        return Ok();
    }

    [HttpPost("rollback-step/{step:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RollbackStep(int step)
    {
        _migrationRunner.Rollback(step);

        return Ok();
    }

    [HttpPost("rollback/all")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult RollbackAll()
    {
        _migrationRunner.RollbackToVersion(0);

        return Ok();
    }
}