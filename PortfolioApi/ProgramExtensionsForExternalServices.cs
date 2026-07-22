using PortfolioApi.ExternalServices.Persistence;
using PortfolioApi.ExternalServices.Persistence.Sqlite;

namespace PortfolioApi;

public static class ProgramExtensionsForExternalServices
{
    extension(IServiceCollection services)
    {
        public IServiceCollection AddExternalServicesPersistence()
        {
            services.AddScoped<IQueryUser, QueryUser>();
            services.AddScoped<IQueryProfile, QueryProfile>();
            services.AddScoped<IQueryProfileNavi, QueryProfileNavi>();
            services.AddScoped<IQueryProfileHero, QueryProfileHero>();
            services.AddScoped<IQueryProfileCard, QueryProfileCard>();
            services.AddScoped<IQueryProfileSocial, QueryProfileSocial>();
            services.AddScoped<IQueryProfilePlus, QueryProfilePlus>();

            return services;
        }
    }
}