using PortfolioApi.Entities;

namespace PortfolioApi.DTO.Response;

public class ProfilePersonResponse
{
    public ProfilePersonResponse(Profile profile)
    {
        Id = profile.Id;
        Email = profile.Email;
        FirstName = profile.FirstName;
        LastName = profile.LastName;
    }

    public int Id { get; set; }
    public string? Email { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}