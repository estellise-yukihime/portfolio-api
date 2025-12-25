namespace PortfolioApi.Entities;

public class ProfileLanguage
{
    public int Id { get; set; }
    public string? Language { get; set; }
    public string? Label { get; set; }
    public string? LabelLevel { get; set; }
    public float? Proficiency { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}