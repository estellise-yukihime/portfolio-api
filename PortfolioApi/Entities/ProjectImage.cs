namespace PortfolioApi.Entities;

public class ProjectImage
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string? ImgUrl { get; set; }
}