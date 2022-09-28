using Project.AVIew.OtherAPI.Model.OpenWeather;
using Project.AVIew.OtherAPI.Model.Tomorrow;
using System.Threading.Tasks;

namespace Project.AVIew.Services
{

    public interface IEventProvider
    {
        Task AddTomorrowWeatherHistiry(IntervalsByDate[] intervalsByDate);

        Task AddOpenWeatherWeatherHistiry(Lists[] lists);
    }
}
