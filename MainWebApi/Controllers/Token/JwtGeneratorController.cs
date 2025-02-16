using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Asp.Versioning;
using MainWebApi.DTO.Request;
using MainWebApi.DTO.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace MainWebApi.Controllers;

[ApiController]
[ApiVersion(1)]
[Route("api/v{version:apiVersion}/tokens/jwt")]
[Consumes("application/json")]
[Produces("application/json")]
[AllowAnonymous]
public class JwtGeneratorController : ControllerBase
{
    [HttpPost]
    public IActionResult GenerateToken(JwtGenerateRequest jwtGenerate)
    {
        var permissions = jwtGenerate.Permissions;
        var permissionsClaims = default(List<Claim>);

        if (permissions != null)
        {
            var set = permissions.Split(" ")
                .Select(x => new Claim("permissions", x))
                .ToList();
            
            permissionsClaims = set;
        }
        
        var signingCredential = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF32.GetBytes("portfolio")), SecurityAlgorithms.HmacSha256);
        var token = new JwtSecurityToken(
            issuer: "portfolio",
            audience: "portfolio-app",
            expires: DateTime.UtcNow.AddHours(1),
            claims: permissionsClaims,
            signingCredentials: signingCredential);
        
        var tokenString = new JwtSecurityTokenHandler()
            .WriteToken(token);
        
        return Ok(new JwtGenerateResponse
        {
            TokenType = "Bearer",
            AccessToken = tokenString,
            ExpiresIn = TimeSpan.FromHours(1).TotalSeconds
        });
    }
}