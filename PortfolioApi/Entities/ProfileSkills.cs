namespace PortfolioApi.Entities;

public class ProfileSkills
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public float Proficiency { get; set; }
    public DateTime? CreatedAt { get; set; }
}