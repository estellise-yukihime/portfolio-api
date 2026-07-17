using PortfolioApi.DTO;

namespace PortfolioApi.Services;

public interface IProfileNaviService
{
    Task<ProducesEntity<ProfileNavi>> GetProfileNavi(Guid profileId);
}