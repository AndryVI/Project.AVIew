using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using OpenWeatherAPI;
using Project.AVIew.OtherAPI.Model.Tomorrow;
using Project.AVIew.OtherAPI.Model.OpenWeather;
using RestSharp;
using System.Threading.Tasks;

namespace Project.AVIew.OtherAPI.Services
{
    /*
     * https://docs.tomorrow.io/reference/data-layers-overview
     */
    public class APIServices : IAPIServices
    {
        private IConfiguration _configuration;
        private string _apiKey_OpenWeathe;
        private string _apiKey_Tomorrow;

        public APIServices(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiKey_OpenWeathe = _configuration["ApiKey_OpenWeather"];
            _apiKey_Tomorrow = _configuration["ApiKey_Tomorrow"];
        }

        public async Task<QueryResponse> GetWeatherByOpenWeatherAPI(string city)
        {
            var openWeatherAPI = new OpenWeatherApiClient(_apiKey_OpenWeathe);

            var query = await openWeatherAPI.QueryAsync(city);


            return query;
        }

        public async Task<ResponsOpenWeatherAPI> GetWeatherByOpenWeatherAPIv25()
        {
            var client = new RestClient("https://api.openweathermap.org/data/2.5/");
            var request = new RestRequest($"forecast?lat=50.4755&lon=30.5198&appid={_apiKey_OpenWeathe}&units=metric", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Encoding", "gzip");
            RestResponse response = await client.ExecuteAsync(request);

            var responsOpenWeather = JsonConvert.DeserializeObject<ResponsOpenWeatherAPI>(response.Content);

            return responsOpenWeather;
        }


        public async Task<RestResponse> GetWeatherByTomorrowAPI()
        {
            var client = new RestClient("https://api.tomorrow.io/");
            var request = new RestRequest($"v4/timelines?location=42.3478%2C%20-71.0466&fields=temperature&units=metric&timesteps=1h&startTime=now&endTime=nowPlus6h&apikey={_apiKey_Tomorrow}", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Encoding", "gzip");
            RestResponse response = await client.ExecuteAsync(request);

            return response;
        }
        public async Task<ResponsTomorrowAPI> PostWeatherByTomorrowAPI()
        {

            var client = new RestClient("https://api.tomorrow.io/v4/");
            var request = new RestRequest($"timelines?apikey={_apiKey_Tomorrow}", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddHeader("Accept-Encoding", "gzip");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\"location\":\"50.4755, 30.5198\"" +
                                                     ",\"fields\":[\"temperature\"" +
                                                                 ",\"weatherCode\"" +
                                                                 ",\"humidity\"" +
                                                                 ",\"windSpeed\"" +
                                                                 ",\"windDirection\"" +
                                                                 ",\"precipitationIntensity\"" +
                                                                 ",\"precipitationProbability\"" +
                                                                 ",\"precipitationType\"" +
                                                                 ",\"visibility\"" +
                                                                 ",\"cloudCover\"" +
                                                                 ",\"grassIndex\"]" +
                                                     ",\"units\":\"metric\"" +
                                                     ",\"timesteps\":[\"1h\"]" +
                                                     ",\"startTime\":\"now\"" +
                                                     ",\"endTime\":\"nowPlus6h\"}", ParameterType.RequestBody);

            RestResponse execute = await client.ExecuteAsync(request);

            var responsTomorrow = JsonConvert.DeserializeObject<ResponsTomorrowAPI>(execute.Content);

            return responsTomorrow;
        }

    }
}
