using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryUserEnabledDbOperation
{
    Task<ProfileEnableDbOperation?> FindFromUser(int profileId);
    Task<ProfileEnableDbOperation?> FindFromUserEmail(string email);
}