namespace PortfolioApi.Entities;

public class UserEnabledDbOperation
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public bool Read { get; set; }
    public bool Insert { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}