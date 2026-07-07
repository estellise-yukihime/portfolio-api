using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryProfile
{
    Task Insert(Profile profile);
    Task Update(Profile profile);
    Task Delete(int id);
}