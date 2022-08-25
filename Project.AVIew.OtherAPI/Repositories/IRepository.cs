using OpenWeatherAPI;
using System.Threading.Tasks;

namespace Project.AVIew.OtherAPI
{
    public class Repository : IRepository
    {
        public async Task<QueryResponse> GetWeather(string city)
        {
            var openWeatherAPI = new OpenWeatherAPI.OpenWeatherApiClient("e578eb444e0a9425fd34ae7bacdc430a");

            var query = await openWeatherAPI.QueryAsync(city);

            return query;
        }
    }
}
