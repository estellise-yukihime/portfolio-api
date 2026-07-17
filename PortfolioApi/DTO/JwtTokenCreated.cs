namespace PortfolioApi.DTO;

public class JwtTokenCreated
{
    public string? TokenType { get; set; }
    public string? AccessToken { get; set; }
    public double ExpiresIn { get; set; }
}