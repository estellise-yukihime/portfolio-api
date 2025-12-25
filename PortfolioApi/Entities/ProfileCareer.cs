namespace PortfolioApi.Entities;

public class ProfileCareer
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int ProfileId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Work { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}