using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using Project.AVIew.OtherAPI.Services;
using Project.AVIew.Services;

namespace Project.AVIew.Controllers
{
    public class WeatherController : Controller
    {
        private readonly IAPIServices _apiService;
        private readonly IEventProvider _eventProvider;
        private readonly ILogger<WeatherController> _logger;


        public WeatherController(ILogger<WeatherController> logger, IAPIServices apiService, IEventProvider eventProvider)
        {
            _logger = logger;
            _apiService = apiService;
            _eventProvider = eventProvider;
        }
        public async Task<IActionResult> TomorrowWeather()
        {
            var date = await _apiService.PostWeatherByTomorrowAPI();

            await _eventProvider.AddTomorrowWeatherHistiry(date.Data.Timelines[0].Intervals);

            return View(date.Data.Timelines[0]);
        }

        public async Task<IActionResult> OpenWeatherWeather()
        {
            var date = await _apiService.GetWeatherByOpenWeatherAPIv25Bulk();

            var today = DateTime.Now.Day;

            var rangeTempToday = date.List.Where(list => list.Dt_Txt.Day == today).ToArray();

            await _eventProvider.AddOpenWeatherWeatherHistiry(rangeTempToday);

            return View(rangeTempToday);
        }
    }
}
