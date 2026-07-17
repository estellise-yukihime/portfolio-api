using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryProfileNavi
{
    Task<Profile?> FindNaviFromExternalId(Guid uuid);
}