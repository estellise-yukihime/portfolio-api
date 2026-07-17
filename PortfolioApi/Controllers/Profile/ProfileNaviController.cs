using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTO;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers.Profile;

[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}/profiles/{profileId:guid}/navi")]
public class ProfileNaviController : ControllerBase
{
    private readonly IProfileNaviService _profileNaviService;

    public ProfileNaviController(IProfileNaviService profileNaviService)
    {
        _profileNaviService = profileNaviService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(ProfileNavi), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProfileNavi(Guid profileId)
    {
        var profile = await _profileNaviService.GetProfileNavi(profileId);

        if (profile is ProducesEntityFail<ProfileNavi>)
        {
            return Problem(statusCode: profile.StatusCode, title: profile.Error, detail: profile.Description);
        }

        return Ok(profile.Entity!);
    }
}