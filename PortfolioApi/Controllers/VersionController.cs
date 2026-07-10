using System.Diagnostics;
using System.Reflection;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace PortfolioApi.Controllers;

[ApiVersion(1)]
[ApiController]
[Route("api/v{version:apiVersion}/version")]
public class VersionController : ControllerBase
{
    [HttpGet]
    public IActionResult GetVersion()
    {
        var version = Assembly.GetExecutingAssembly().GetName().Version;
        var fileVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)
            .FileVersion;
        var prodVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location)
            .ProductVersion;

        return Ok(new
        {
            AssemblyVersion = version,
            FileVersion = fileVersion,
            ProductVersion = prodVersion
        });
    }
}