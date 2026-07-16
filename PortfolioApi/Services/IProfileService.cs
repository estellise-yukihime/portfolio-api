using PortfolioApi.Entities;

namespace PortfolioApi.Services;

public interface IProfileService
{
    Task<ProducesEntity<Profile>> GetProfileNavi(Guid profileId);
    Task<ProducesEntity<ProfileHero>> GetProfileHero(Guid profileId);
    Task<ProducesEntity<List<ProfileSocial>>> GetProfileSocial(Guid profileId);
}