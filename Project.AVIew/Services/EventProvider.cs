using Project.AVIew.OtherAPI.Model.Tomorrow;
using System.Threading.Tasks;
using System.Linq;
using System;
using Project.AVIew.EF.Repositories;
using Project.AVIew.EF.Entities.Weather;
using Project.AVIew.OtherAPI.Model.OpenWeather;
using Project.AVIew.EF.Enums;

namespace Project.AVIew.Services
{
    public class EventProvider: IEventProvider
    {
        private readonly IWeatherRepository _weatherRepository;
        public EventProvider(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository;
        }
        public async Task AddTomorrowWeatherHistiry(IntervalsByDate[] intervalsByDate)
        {
            var saveDate = intervalsByDate.Select(tempdate => new WeatherHistory() {
                                                                                            Id = Guid.NewGuid(),
                                                                                            Service = WeatherType.Tomorrow.ToString(),
                                                                                            DateTime = tempdate.StartTime,
                                                                                            Humidity = tempdate.Values.Humidity,
                                                                                            Temperature = tempdate.Values.Temperature,
                                                                                            WindSpeed = tempdate.Values.WindSpeed})
                                          .ToList();
            await _weatherRepository.AddWeatherHistory(saveDate);
        }
        public async Task AddOpenWeatherWeatherHistiry(Lists[] lists)
        {
            var saveDate = lists.Select(tempdate => new WeatherHistory()
                                                                        {
                                                                            Id = Guid.NewGuid(),
                                                                            Service = WeatherType.OpenWeather.ToString(),
                                                                            DateTime = tempdate.Dt_Txt,
                                                                            Humidity = tempdate.Main.Humidity,
                                                                            Temperature = tempdate.Main.Temp,
                                                                            WindSpeed = tempdate.Wind.Speed
                                                                        })
                                          .ToList();
            await _weatherRepository.AddWeatherHistory(saveDate);
        }
    }
}
