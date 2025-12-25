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

    public async Task<ProducesEntity<List<Profile>>> ListProfileFromUser(string userId)
    {
        var profiles = await _queryProfile.ListFromUser(userId);
        
        return new ProducesEntityGood<List<Profile>>(profiles);   
    }

    public async Task<ProducesEntity<Profile>> InsertProfile(Profile profile)
    {
        // add guards on profile

        var value = await _queryProfile.Insert(profile);

        return new ProducesEntityGood<Profile>(value);
    }
}