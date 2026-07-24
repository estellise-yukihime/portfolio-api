using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryProfileWork
{
    Task<List<ProfileCareer>?> FindProfileCareersByExternalId(Guid profileId);
}