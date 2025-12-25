namespace PortfolioApi.Entities;

public class Project
{
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImgUrl { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public List<ProjectImage> Imgs { get; set; } = [];
    public List<ProjectTechnology> Techs { get; set; } = [];

}