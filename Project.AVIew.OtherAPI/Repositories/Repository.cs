using Microsoft.Extensions.Configuration;
using OpenWeatherAPI;
using System.Threading.Tasks;

namespace Project.AVIew.OtherAPI
{
    public class Repository : IRepository
    {
        private IConfiguration _configuration;
        public Repository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<QueryResponse> GetWeather(string city)
        {
            var openWeatherAPI = new OpenWeatherAPI.OpenWeatherApiClient(_configuration["ApiKey"]);

            var query = await openWeatherAPI.QueryAsync(city);

            return query;
        }
    }
}
