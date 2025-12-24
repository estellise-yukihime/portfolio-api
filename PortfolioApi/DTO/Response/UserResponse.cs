using PortfolioApi.Entities;

namespace PortfolioApi.DTO.Response;

public class UserResponse
{
    public UserResponse(User user)
    {
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email;
        DateOfBirth = user.DateOfBirth;
        PhoneNumber = user.PhoneNumber;
    }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? DateOfBirth { get; set; }
    public string? PhoneNumber { get; set; }
}