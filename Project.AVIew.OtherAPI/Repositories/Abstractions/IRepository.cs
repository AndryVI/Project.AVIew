using System.Threading.Tasks;
using OpenWeatherAPI;
using RestSharp;

namespace Project.AVIew.OtherAPI
{
    public interface IRepository
    {
        Task<QueryResponse> GetWeatherByOpenWeatherAPI(string city);
        Task<RestResponse> GetWeatherByTomorrowAPI();
    }
}
