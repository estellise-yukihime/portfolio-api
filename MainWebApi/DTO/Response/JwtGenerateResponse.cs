namespace MainWebApi.DTO.Response;

public class JwtGenerateResponse
{
    public string? TokenType { get; set; }
    public string? AccessToken { get; set; }
    public double ExpiresIn { get; set; }
}