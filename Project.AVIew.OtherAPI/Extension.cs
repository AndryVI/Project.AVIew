using Microsoft.Extensions.DependencyInjection;
using Project.AVIew.OtherAPI.Services;

namespace Project.AVIew.OtherAPI
{
    public static class Extension
    {
        public static IServiceCollection AddOtherAPI(this IServiceCollection services)
        {
            services.AddTransient<IAPIServices, APIServices>();

            return services;
        }
    }
}