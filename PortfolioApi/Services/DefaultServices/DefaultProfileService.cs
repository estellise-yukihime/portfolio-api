using PortfolioApi.Entities;
using PortfolioApi.ExternalServices.Persistence;

namespace PortfolioApi.Services.DefaultServices;

public class DefaultProfileService : IProfileService
{
    private readonly IQueryProfile _queryProfile;
    private readonly IQueryProfileHero _queryProfileHero;
    private readonly IQueryProfileSocial _queryProfileSocial;

    public DefaultProfileService(IQueryProfile queryProfile,
        IQueryProfileHero queryProfileHero,
        IQueryProfileSocial queryProfileSocial)
    {
        _queryProfile = queryProfile;
        _queryProfileHero = queryProfileHero;
        _queryProfileSocial = queryProfileSocial;
    }

    public async Task<ProducesEntity<Profile>> GetProfile(Guid profileId)
    {
        var profile = await _queryProfile.FindFromExternalId(profileId);

        if (profile is null)
        {
            return new ProducesEntityFail<Profile>(StatusCodes.Status404NotFound, "Not Found", "No profile found");
        }

        return new ProducesEntityGood<Profile>(profile);
    }

    public async Task<ProducesEntity<ProfileHero>> GetProfileHero(Guid profileId)
    {
        var profileHero = await _queryProfileHero.FindFromProfileExternalId(profileId);

        if (profileHero is null)
        {
            return new ProducesEntityFail<ProfileHero>(StatusCodes.Status404NotFound, "Not Found",
                "No profile hero found");
        }

        return new ProducesEntityGood<ProfileHero>(profileHero);
    }

    public async Task<ProducesEntity<List<ProfileSocial>>> GetProfileSocial(Guid profileId)
    {
        var profileSocial = await _queryProfileSocial.ListFromProfileExternalId(profileId);

        return new ProducesEntityGood<List<ProfileSocial>>(profileSocial);
    }
}