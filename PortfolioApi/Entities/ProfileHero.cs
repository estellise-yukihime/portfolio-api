namespace PortfolioApi.Entities;

public class ProfileHero
{
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public string? Head { get; set; }
    public string? Text { get; set; }
}