using PortfolioApi.Entities;

namespace PortfolioApi.DTO.Response;

public class UserResponse
{
    public UserResponse(User user)
    {
        Username = user.Username;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        DateOfBirth = user.DateOfBirth;
        PhoneNumber = user.PhoneNumber;
        CreatedAt = user.CreatedAt;
        UpdatedAt = user.UpdatedAt;
    }

    public string? Username { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}