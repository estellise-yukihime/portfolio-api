using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryProfileSocial
{
    Task<List<ProfileSocial>> ListFromProfileExternalId(Guid uuid);
}