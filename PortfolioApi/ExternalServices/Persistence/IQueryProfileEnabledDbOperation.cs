using PortfolioApi.Entities;

namespace PortfolioApi.ExternalServices.Persistence;

public interface IQueryProfileEnabledDbOperation
{
    Task<ProfileEnableDbOperation?> FindFromProfileId(int profileId);
}