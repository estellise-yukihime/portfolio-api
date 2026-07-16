using PortfolioApi.Entities;
using PortfolioApi.EntityValueObject;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryProfile
{
    Task<Paginated<Profile>> ListCardFromPage(Pagination pagination);
    Task<Profile?> FindFromExternalId(Guid uuid);
    Task<Profile?> FindNaviFromExternalId(Guid uuid);
    Task Insert(Profile profile);
    Task Update(Profile profile);
    Task Delete(int id);
}