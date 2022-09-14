using Microsoft.AspNetCore.Mvc;
using Project.AVIew.Model;
using Project.AVIew.OtherAPI.Model.Tomorrow;
using System.Threading.Tasks;
using System;
using Newtonsoft.Json;
using Project.AVIew.OtherAPI.Services;
using Project.AVIew.Services;

namespace Project.AVIew.Controllers
{

    public class HomeController : Controller
    {
        private readonly IAPIServices _repository;
        private readonly IEventProvider _eventProvider;
        private ResponsTomorrowAPI answer;
        public HomeController(IAPIServices repository, IEventProvider eventProvider)
        {
            _repository = repository;
            _eventProvider = eventProvider;
            answer = new ResponsTomorrowAPI() {
                Data = new Data()
                {
                    Timelines = new Timelines[] {
                        new Timelines(){
                                Timestep = "1h",
                                EndTime = new DateTime(2022,08,29,19,0,0),
                                StartTime = new DateTime(2022, 08, 29, 13, 0, 0),
                                Intervals = new IntervalsByDate[]{
                                        new IntervalsByDate(){
                                            StartTime = new DateTime(2022, 08, 29, 13, 0, 0),
                                            Values = new Values()   {
                                                                    Temperature = 20.06,
                                                                    WeatherCode = (WeatherCodes)1001,
                                                                    Humidity = 89,
                                                                    WindSpeed = 2.26,
                                                                    WindDirection  = 287.5,
                                                                    PrecipitationIntensity = 0,
                                                                    PrecipitationProbability = 0,
                                                                    PrecipitationType = (PrecipitationTypes)0,
                                                                    Visibility = 15.1,
                                                                    CloudCover = 84,
                                                                    GrassIndex = 0}
                                            },
                                        new IntervalsByDate(){
                                            StartTime = new DateTime(2022, 08, 29, 14, 0, 0),
                                            Values = new Values()   {
                                                                    Temperature = 24.12,
                                                                    WeatherCode = (WeatherCodes)1100,
                                                                    Humidity = 81.87,
                                                                    WindSpeed = 3.34,
                                                                    WindDirection  = 246.11,
                                                                    PrecipitationIntensity = 0,
                                                                    PrecipitationProbability = 0,
                                                                    PrecipitationType = (PrecipitationTypes)0,
                                                                    Visibility = 16.0,
                                                                    CloudCover = 13.31,
                                                                    GrassIndex = 0}
                                            },
                                        new IntervalsByDate(){
                                            StartTime = new DateTime(2022, 08, 29, 15, 0, 0),
                                            Values = new Values()   {
                                                                    Temperature = 26.4,
                                                                    WeatherCode = (WeatherCodes)1100,
                                                                    Humidity = 72.62,
                                                                    WindSpeed = 3.86,
                                                                    WindDirection  = 239.98,
                                                                    PrecipitationIntensity = 0,
                                                                    PrecipitationProbability = 0,
                                                                    PrecipitationType = (PrecipitationTypes)0,
                                                                    Visibility = 16.0,
                                                                    CloudCover = 16.14,
                                                                    GrassIndex = 0}
                                            },
                                        new IntervalsByDate(){
                                            StartTime = new DateTime(2022, 08, 29, 16, 0, 0),
                                            Values = new Values()   {
                                                                    Temperature = 28.1,
                                                                    WeatherCode = (WeatherCodes)1100,
                                                                    Humidity = 64.73,
                                                                    WindSpeed = 4.38,
                                                                    WindDirection  = 237.65,
                                                                    PrecipitationIntensity = 0,
                                                                    PrecipitationProbability = 0,
                                                                    PrecipitationType = (PrecipitationTypes)0,
                                                                    Visibility = 16.0,
                                                                    CloudCover = 33.93,
                                                                    GrassIndex = 0}
                                            },
                                        new IntervalsByDate(){
                                            StartTime = new DateTime(2022, 08, 29, 17, 0, 0),
                                            Values = new Values()   {
                                                                    Temperature = 29.65,
                                                                    WeatherCode = (WeatherCodes)1000,
                                                                    Humidity = 55.51,
                                                                    WindSpeed = 4.83,
                                                                    WindDirection  = 231.9,
                                                                    PrecipitationIntensity = 0,
                                                                    PrecipitationProbability = 0,
                                                                    PrecipitationType = (PrecipitationTypes)0,
                                                                    Visibility = 16.0,
                                                                    CloudCover = 3.51,
                                                                    GrassIndex = 0}
                                            },
                                        new IntervalsByDate(){
                                            StartTime = new DateTime(2022, 08, 29, 18, 0, 0),
                                            Values = new Values()   {
                                                                    Temperature = 30.78,
                                                                    WeatherCode = (WeatherCodes)1100,
                                                                    Humidity = 50.13,
                                                                    WindSpeed = 4.97,
                                                                    WindDirection  = 228.97,
                                                                    PrecipitationIntensity = 0,
                                                                    PrecipitationProbability = 0,
                                                                    PrecipitationType = (PrecipitationTypes)0,
                                                                    Visibility = 16.0,
                                                                    CloudCover = 12.91,
                                                                    GrassIndex = 0}
                                            },
                                        new IntervalsByDate(){
                                            StartTime = new DateTime(2022, 08, 29, 19, 0, 0),
                                            Values = new Values()   {
                                                                    Temperature = 31.32,
                                                                    WeatherCode = (WeatherCodes)1001,
                                                                    Humidity = 45.28,
                                                                    WindSpeed = 4.97,
                                                                    WindDirection  = 228.71,
                                                                    PrecipitationIntensity = 0,
                                                                    PrecipitationProbability = 0,
                                                                    PrecipitationType = (PrecipitationTypes)0,
                                                                    Visibility = 16.0,
                                                                    CloudCover = 75.5,
                                                                    GrassIndex = 0}
                                            },

                                }
                        }
                    }
                } 
            };

        }
        public async Task<IActionResult> Index()
        {
            //var json = await _repository.PostWeatherByTomorrowAPI();


            //var yourClass = JsonConvert.DeserializeObject<ResponsTomorrowAPI>(json.Content);

            await _eventProvider.AddTomorrowWeatherHistiry(answer.Data.Timelines[0].Intervals);

            return View(answer.Data.Timelines[0]);
            //return View(yourClass.Data.Timelines[0]);
            
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Archive()
        {
            return View();
        }

    }
}