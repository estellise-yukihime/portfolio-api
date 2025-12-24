using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryUser
{
    Task<User?> FindFromEmail(string email);
}