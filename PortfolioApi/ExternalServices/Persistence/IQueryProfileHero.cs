using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryProfileHero
{
    Task<ProfileHero?> FindFromProfileExternalId(Guid uuid);
}