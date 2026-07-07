using PortfolioApi.Services;
using PortfolioApi.Services.DefaultServices;

namespace PortfolioApi;

public static class ProgramExtensionsForServices
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddDefaultServices()
        {
            services.AddScoped<IUserService, DefaultUserService>();
            services.AddScoped<IProfileService, DefaultProfileService>();

            return services;
        }
    }
}