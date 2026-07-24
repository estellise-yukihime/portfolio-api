using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTO;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers.Profile;

[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}/profiles/{profileId:guid}/work")]
public class ProfileWorkController : ControllerBase
{
    private readonly IProfileWorkService _profileWorkService;

    public ProfileWorkController(IProfileWorkService profileWorkService)
    {
        _profileWorkService = profileWorkService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid profileId)
    {
        var work = await _profileWorkService.GetProfileWork(profileId);

        if (work is ProducesEntityFail<List<ProfileWorkCareer>> fail)
        {
            return Problem(statusCode: fail.StatusCode, title: fail.Error, detail: fail.Description);
        }

        return Ok(work.Entity);
    }
}
