namespace PortfolioApi.Entities;

public class Profile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Photo { get; set; }
    public string? Title { get; set; }
    public string? State { get; set; }
    public string? Summary { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}