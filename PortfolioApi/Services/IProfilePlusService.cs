using PortfolioApi.DTO;

namespace PortfolioApi.Services;

public interface IProfilePlusService
{
    Task<ProducesEntity<ProfilePlus>> GetProfilePlus(Guid profileId);
}