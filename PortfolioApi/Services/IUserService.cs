using PortfolioApi.Entities;

namespace PortfolioApi.Services;

public interface IUserService
{
    Task<ProducesEntity<User>> FindUserFromEmail(string email);
}