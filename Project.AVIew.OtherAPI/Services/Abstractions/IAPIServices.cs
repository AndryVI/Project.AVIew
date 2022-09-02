using System.Threading.Tasks;
using OpenWeatherAPI;
using Project.AVIew.OtherAPI.Model.Tomorrow;
using RestSharp;

namespace Project.AVIew.OtherAPI.Services
{
    public interface IAPIServices
    {
        Task<QueryResponse> GetWeatherByOpenWeatherAPI(string city);
        Task<RestResponse> GetWeatherByOpenWeatherAPIv25();
        Task<RestResponse> GetWeatherByTomorrowAPI();
        Task<ResponsTomorrowAPI> PostWeatherByTomorrowAPI();
    }
}
