using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Controllers.Profile;

[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}profiles/{profileId}/projects")]
public class ProfileProjectsController : ControllerBase
{
    
}