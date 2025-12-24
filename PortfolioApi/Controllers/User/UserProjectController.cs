using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Controllers.User;


[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}/user/{email}/projects")]
public class UserProjectController : ControllerBase
{
    
}