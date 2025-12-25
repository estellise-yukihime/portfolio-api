using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Controllers.User;

[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}/users/{email}/profiles")]
public class UserProfilesController
{
    
}