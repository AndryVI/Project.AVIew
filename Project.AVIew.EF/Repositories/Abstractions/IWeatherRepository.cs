using Project.AVIew.EF.Entities.User;
using Project.AVIew.EF.Entities.Weather;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project.AVIew.EF.Repositories
{
    public interface IWeatherRepository
    {
        Task AddWeatherHistory(List<WeatherHistory> weatherHistory);
    }
}
