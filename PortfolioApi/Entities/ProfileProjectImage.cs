namespace PortfolioApi.Entities;

public class ProfileProjectImage
{
    public int Id { get; set; }
    public int ProjectId { get; set; }
    public string? ImgUrl { get; set; }
}