using Microsoft.Extensions.Configuration;
using OpenWeatherAPI;
using RestSharp;
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

        public async Task<QueryResponse> GetWeatherByOpenWeatherAPI(string city)
        {
            var openWeatherAPI = new OpenWeatherAPI.OpenWeatherApiClient(_configuration["ApiKey"]);

            var query = await openWeatherAPI.QueryAsync(city);

            return query;
        }

        public async Task<RestResponse> GetWeatherByTomorrowAPI()
        {
            var client = new RestClient("https://api.tomorrow.io/");
            var request = new RestRequest("v4/timelines?location=42.3478%2C%20-71.0466&fields=temperature&units=metric&timesteps=1h&startTime=now&endTime=nowPlus6h&apikey=9lSpYZhU3ZvQX9EkzqbI7hY6e9XdMVFD", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Encoding", "gzip");
            RestResponse response = await client.ExecuteAsync(request);

            return response;
        }
    }
}
