using Microsoft.AspNetCore.Mvc;
using Project.AVIew.OtherAPI.Model.Tomorrow;
using System.Threading.Tasks;
using System;
using System.Linq;
using Newtonsoft.Json;
using Project.AVIew.OtherAPI.Services;
using Project.AVIew.Services;
using Project.AVIew.OtherAPI.Model.OpenWeather;
using System.Collections.Generic;
using Project.AVIew.Model;

namespace Project.AVIew.Controllers
{

    public class HomeController : Controller
    {
        private readonly IAPIServices _apiService;
        public HomeController(IAPIServices apiService)
        {
            _apiService = apiService;
        }
        public async Task<IActionResult> Index()
        {
            var responsTomorrow = await _apiService.PostWeatherByTomorrowAPI();
            var responsOpenWeather = await _apiService.GetWeatherByOpenWeatherAPIv25Bulk();

            var comparisonsWeatherAPI = new List<ComparisonsWeatherAPI>();
            foreach (var openWeather in responsOpenWeather.List)
            {
                foreach (var tomorrow in responsTomorrow.Data.Timelines[0].Intervals)
                {
                    if (openWeather.Dt_Txt == tomorrow.StartTime)
                    {
                        comparisonsWeatherAPI.Add(new ComparisonsWeatherAPI(){
                            TemperatureOpenWeather = openWeather.Main.Temp,
                            CodOpenWeather = openWeather.Weather[0].Icon,
                            TemperatureTomorrow = tomorrow.Values.Temperature,
                            CodTomorrow = tomorrow.Values.WeatherCode,
                            Time = openWeather.Dt_Txt
                        });
                    }
                }
            }

            return View(comparisonsWeatherAPI.ToArray());
        }


        public IActionResult About()
        {
            return View();
        }
    }
}