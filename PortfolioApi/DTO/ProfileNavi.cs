using PortfolioApi.Entities;

namespace PortfolioApi.DTO;

public class ProfileNavi
{
    public ProfileNavi(Profile profile)
    {
        Id = profile.Id;
        Email = profile.Email;
        FirstName = profile.FirstName;
        LastName = profile.LastName;
        CV = profile.CV;
        Socials = profile.Socials;
    }

    public int Id { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public ProfileCV? CV { get; set; }
    public List<ProfileSocial>? Socials { get; set; }
}