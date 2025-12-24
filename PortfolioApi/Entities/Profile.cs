namespace PortfolioApi.Entities;

public class Profile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? ImgUrl { get; set; }
    public string? Summary { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? PhoneNumber { get; set; }
}