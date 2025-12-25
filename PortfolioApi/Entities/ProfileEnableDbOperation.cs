namespace PortfolioApi.Entities;

public class ProfileEnableDbOperation
{
    public int Id { get; set; }
    public int ProfileId { get; set; }
    public bool Read { get; set; }
    public bool Insert { get; set; }
    public bool Update { get; set; }
    public bool Delete { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}