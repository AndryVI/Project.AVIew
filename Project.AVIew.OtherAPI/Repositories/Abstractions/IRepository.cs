using System.Threading.Tasks;
using OpenWeatherAPI;

namespace Project.AVIew.OtherAPI
{
    public interface IRepository
    {
        Task<QueryResponse> GetWeather(string city);
    }
}
