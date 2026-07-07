using PortfolioApi.Entities;

namespace PortfolioApi.DTO.Response;

public class UserResponse
{
    public UserResponse(User user)
    {
        Email = user.Email;
        CreatedAt = user.CreatedAt;
        UpdatedAt = user.UpdatedAt;
    }

    public string? Email { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}