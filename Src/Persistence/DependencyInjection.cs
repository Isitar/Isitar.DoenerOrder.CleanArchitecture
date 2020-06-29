namespace Isitar.DoenerOrder.CleanArchitecture.Persistence
{
    using Application.Common.Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DoenerDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DoenerDbConnection"),
                    o => o.UseNodaTime()
                )
            );

            services.AddScoped<IDoenerDbContext, DoenerDbContext>();
            return services;
        }
    }
}