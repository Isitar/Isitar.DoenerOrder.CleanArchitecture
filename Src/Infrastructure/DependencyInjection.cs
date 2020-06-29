namespace Isitar.DoenerOrder.CleanArchitecture.Infrastructure
{
    using Common;
    using Microsoft.Extensions.DependencyInjection;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<IInstant, SystemClockInstant>();
            return services;
        }
    }
}