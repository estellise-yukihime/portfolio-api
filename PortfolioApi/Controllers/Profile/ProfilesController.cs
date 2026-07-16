using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.DTO.Response;
using PortfolioApi.Entities;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers.Profile;

[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}/profiles")]
public class ProfilesController : ControllerBase
{
    private readonly IProfileService _profileService;

    public ProfilesController(IProfileService profileService)
    {
        _profileService = profileService;
    }

    [HttpGet("cards")]
    [ProducesResponseType(typeof(IEnumerable<Entities.Profile>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProfiles()
    {
        return Ok();
    }

    [HttpGet("{profileId:guid}")]
    [ProducesResponseType(typeof(Entities.Profile), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProfile(Guid profileId)
    {
        var profile = await _profileService.GetProfileNavi(profileId);

        if (profile is ProducesEntityFail<Entities.Profile>)
        {
            return Problem(statusCode: profile.StatusCode, title: profile.Error, detail: profile.Description);
        }

        return Ok(profile.Entity);
    }

    [HttpGet("{profileId:guid}/navi")]
    [ProducesResponseType(typeof(ProfilePersonResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProfileNavi(Guid profileId)
    {
        var profile = await _profileService.GetProfileNavi(profileId);

        if (profile is ProducesEntityFail<Entities.Profile>)
        {
            return Problem(statusCode: profile.StatusCode, title: profile.Error, detail: profile.Description);
        }

        return Ok(new ProfilePersonResponse(profile.Entity!));
    }

    [HttpGet("{profileId:guid}/hero")]
    [ProducesResponseType(typeof(ProfileHero), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProfileHero(Guid profileId)
    {
        var profileHero = await _profileService.GetProfileHero(profileId);

        if (profileHero is ProducesEntityFail<ProfileHero> fail)
        {
            return Problem(statusCode: fail.StatusCode, title: fail.Error, detail: fail.Description);
        }

        return Ok(profileHero.Entity);
    }

    [HttpGet("{profileId:guid}/link")]
    [ProducesResponseType(typeof(ProfileSocial[]), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetProfileLink(Guid profileId)
    {
        var profileSocial = await _profileService.GetProfileSocial(profileId);

        return Ok(profileSocial.Entity);
    }
}