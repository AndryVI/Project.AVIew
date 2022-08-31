using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using Project.AVIew.EF.Repositories;

namespace Project.AVIew.EF
{
    public static class AVIewDbContextExtension
    {
        public static IServiceCollection AddBvrIdentityDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = BuildConnectionString(configuration);

            services.AddDbContext<AVIewDbContext>(options =>
            {
                options.UseSqlServer(connectionString);

                if (configuration["ASPNETCORE_ENVIRONMENT"] is not "prod")
                    options.EnableSensitiveDataLogging();
            });

            services.AddAVIewEFRepositories();

            return services;
        }
        public static IServiceCollection AddAVIewEFRepositories(this IServiceCollection services)
        {
            services.AddTransient<IUserRepository, UserRepository>();

            return services;
        }


        private static string BuildConnectionString(IConfiguration config)
            => new SqlConnectionStringBuilder
            {
                DataSource = config["DatabaseDataSource"].Replace(";", ","),
                InitialCatalog = "BVR",
                UserID = config["DatabaseUserId"],
                Password = config["DatabasePassword"],
                TrustServerCertificate = true
            }.ConnectionString;
    }
}
