using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace PortfolioApi.Controllers;

[Route("/error")]
public class ErrorController : ControllerBase
{
    private readonly ProblemDetailsFactory _problemFactory;

    public ErrorController(ProblemDetailsFactory problemFactory)
    {
        _problemFactory = problemFactory;
    }

    public IActionResult HandleError()
    {
        var detail = "";
        var exception = HttpContext.Features.Get<IExceptionHandlerFeature>();

        if (exception is not null)
        {
            detail = exception.Error.Message;
        }

        var problem =
            _problemFactory.CreateProblemDetails(HttpContext,
                StatusCodes.Status500InternalServerError, null, null, detail);

        var result = new ObjectResult(problem)
        {
            StatusCode = problem.Status,
            ContentTypes =
            {
                "application/problem+json"
            }
        };

        return result;
    }
}