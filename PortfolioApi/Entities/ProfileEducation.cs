namespace PortfolioApi.Entities;

public class ProfileEducation
{
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public int SchoolId { get; set; }
    public string? FieldOfStudy { get; set; }
    public string? Degree { get; set; }
    public DateTime? Graduated { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}