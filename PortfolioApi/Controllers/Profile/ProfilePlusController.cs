using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTO;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers.Profile;

[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}/profiles/{profileId:guid}/plus")]
public class ProfilePlusController : ControllerBase
{
    private readonly IProfilePlusService _profilePlusService;

    public ProfilePlusController(IProfilePlusService profilePlusService)
    {
        _profilePlusService = profilePlusService;
    }

    [HttpGet]
    public async Task<IActionResult> Get(Guid profileId)
    {
        var profile = await _profilePlusService.GetProfilePlus(profileId);

        if (profile is ProducesEntityFail<ProfilePlus> fail)
        {
            return Problem(statusCode: fail.StatusCode, title: fail.Error, detail: fail.Description);
        }

        return Ok(profile.Entity);
    }
}