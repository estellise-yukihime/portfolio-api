namespace PortfolioApi.Entities;

public class ProjectTechnology
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string? Tech { get; set; }
}