using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Controllers.User;

[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}/users/{userId}/profiles/{profileId}/projects")]
public class UserProfileProjects : ControllerBase
{
    
}