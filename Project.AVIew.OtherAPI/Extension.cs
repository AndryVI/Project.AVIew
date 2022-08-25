using Microsoft.Extensions.DependencyInjection;

namespace Project.AVIew.OtherAPI
{
    public static class Extension
    {
        public static IServiceCollection AddOtherAPI(this IServiceCollection services)
        {
            services.AddTransient<IRepository, Repository>();

            return services;
        }
    }
}
