using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryProfile
{
    Task<List<Profile>> ListFromUser(string userId);
    Task Insert(Profile profile);
    Task Update(Profile profile);
    Task Delete(int id);
}