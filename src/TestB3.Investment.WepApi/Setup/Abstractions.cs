using TestB3.Investment.Domain;
using TestB3.Investment.WepApi.AutoMapper;

namespace TestB3.Investment.WepApi.Setup
{
    public static class Abstractions
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Investment
            services.AddScoped<ICdbService, CdbService>();
        }

        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(
                typeof(DomainToDtoMappingProfile)
            );
        }
    }
}
