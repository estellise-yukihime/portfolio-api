using PortfolioApi.DTO;
using PortfolioApi.EntityValueObject;

namespace PortfolioApi.Services;

public interface IProfileCardService
{
    Task<ProducesEntity<Paginated<ProfileCard>>> GetProfilesCard(Pagination pagination);
}