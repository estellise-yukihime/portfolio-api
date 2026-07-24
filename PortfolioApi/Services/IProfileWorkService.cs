using PortfolioApi.DTO;

namespace PortfolioApi.Services;

public interface IProfileWorkService
{
    Task<ProducesEntity<List<ProfileWorkCareer>>> GetProfileWork(Guid profileId);
}
