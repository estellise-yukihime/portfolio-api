using PortfolioApi.Entities;
using PortfolioApi.ExternalServices.Persistence;
using PortfolioApi.Services.DefaultServices;

namespace PortfolioApi.Services.DbOperationCheck;

public class CheckOperationUser : IUserService
{
    private readonly DefaultUserService _defaultUserService;
    private readonly IQueryUserEnabledDbOperation _queryUserEnabledDbOperation;

    public CheckOperationUser(DefaultUserService defaultUserService, IQueryUserEnabledDbOperation queryUserEnabledDbOperation)
    {
        _defaultUserService = defaultUserService;
        _queryUserEnabledDbOperation = queryUserEnabledDbOperation;
    }

    public async Task<ProducesEntity<User>> FindUserFromEmail(string email)
    {
        // note:
        //  if no record found, treat as all operations are enabled
        var enabled = await _queryUserEnabledDbOperation.FindFromUserEmail(email);

        if (enabled is { Read: false })
        {
            return new ProducesEntityFail<User>(StatusCodes.Status403Forbidden, "Read operation is disabled");
        }

        return await _defaultUserService.FindUserFromEmail(email);
    }
}