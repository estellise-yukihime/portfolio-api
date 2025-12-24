using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Controllers;

[ApiVersion(1)]
[ApiVersion(2)]
[ApiController]
[Route("api/v{version:apiVersion}/ping")]
public class PingController : ControllerBase
{
    [MapToApiVersion(1)]
    [HttpGet]
    public IActionResult PingV1()
    {
        return Ok();
    }

    [MapToApiVersion(2)]
    [HttpGet]
    public IActionResult PingV2()
    {
        return Ok();
    }
}