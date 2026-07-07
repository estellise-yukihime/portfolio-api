using PortfolioApi.Entities;
using PortfolioApi.ExternalServices.Persistence;

namespace PortfolioApi.Services.DefaultServices;

public class DefaultProfileService : IProfileService
{
    private readonly IQueryProfile _queryProfile;

    public DefaultProfileService(IQueryProfile queryProfile)
    {
        _queryProfile = queryProfile;
    }

    public async Task<ProducesEntity<Profile>> InsertProfile(Profile profile)
    {
        await _queryProfile.Insert(profile);

        return new ProducesEntityGood<Profile>(profile);
    }
}