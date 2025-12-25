using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryProfile
{
    Task<List<Profile>> ListFromUser(string userId);
    Task<Profile> Insert(Profile profile);
}