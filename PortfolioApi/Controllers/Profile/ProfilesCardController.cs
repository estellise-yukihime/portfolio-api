using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using PortfolioApi.EntityValueObject;
using PortfolioApi.Services;

namespace PortfolioApi.Controllers.Profile;

[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}/profiles/cards")]
public class ProfilesCardController : ControllerBase
{
    private readonly IProfileCardService _profileCardService;

    public ProfilesCardController(IProfileCardService profileCardService)
    {
        _profileCardService = profileCardService;
    }

    [HttpGet]
    [ProducesResponseType(typeof(Paginated<Entities.Profile>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProfiles([FromQuery] Pagination pagination)
    {
        var profiles = await _profileCardService.GetProfilesCard(pagination);

        return Ok(profiles.Entity);
    }
}