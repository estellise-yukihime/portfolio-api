using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryProfilePlus
{
    Task<Profile?> FindFromExternalId(Guid profileId);
}