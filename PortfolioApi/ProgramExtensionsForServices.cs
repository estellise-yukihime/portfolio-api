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
            services.AddScoped<IProfileNaviService, DefaultProfileNaviService>();
            services.AddScoped<IProfileHeroService, DefaultProfileHeroService>();
            services.AddScoped<IProfileCardService, DefaultProfileCardService>();
            services.AddScoped<IProfilePlusService, DefaultProfilePlusService>();
            services.AddScoped<IProfileWorkService, DefaultProfileWorkService>();

            return services;
        }
    }
}