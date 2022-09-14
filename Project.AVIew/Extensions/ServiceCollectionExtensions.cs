using Microsoft.Extensions.DependencyInjection;
using Project.AVIew.Services;

namespace Project.AVIew.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<IEventProvider, EventProvider>();

            return services;
        }
    }
}
