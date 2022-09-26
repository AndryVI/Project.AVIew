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

namespace Project.AVIew.Controllers
{

    public class HomeController : Controller
    {
        private readonly IAPIServices _apiService;
        private readonly IEventProvider _eventProvider;
        private ResponsTomorrowAPI answerTomorrow;
        private ResponsOpenWeatherAPI answerOpenWeather;
        public HomeController(IAPIServices apiService, IEventProvider eventProvider)
        {
            _apiService = apiService;
            _eventProvider = eventProvider;
            answerTomorrow = new ResponsTomorrowAPI() {
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
            answerOpenWeather = new ResponsOpenWeatherAPI() {
                Cod = 200,
                Message = "",
                Cnt = "",
                List = new Lists[] {
                      new Lists(){
                        Dt = 117,
                        Main = new Main(){
                            Temp = 7.4,
                            Feels_Like = 12.91,
                            Temp_Min = 11.31,
                            Temp_Max = 13.4,
                            Pressure = 1009,
                            Sea_Level = 1009,
                            Grnd_Level = 1002,
                            Humidity = 81,
                            Temp_Kf  = 2.08},
                        Weather = new Weather[]{
                            new Weather() {
                                Id = 500,
                                Main = "Rain",
                                Description = "light rain",
                                Icon = "10d"},
                        },
                        Clouds = new Clouds(){
                            all = 100,},
                        Wind = new Wind(){
                            Speed = 3.74,
                            Deg = 301,
                            Gust =  3.74},
                        Visibility = 10000,
                        Pop = 1,
                        Dt_Txt = new DateTime(2022, 09, 23, 00, 0, 0)
                    },
                      new Lists(){
                        Dt = 118,
                        Main = new Main(){
                            Temp = 09.4,
                            Feels_Like = 12.91,
                            Temp_Min = 11.31,
                            Temp_Max = 13.4,
                            Pressure = 1009,
                            Sea_Level = 1009,
                            Grnd_Level = 1002,
                            Humidity = 81,
                            Temp_Kf  = 2.08},
                        Weather = new Weather[]{
                            new Weather() {
                                Id = 500,
                                Main = "Rain",
                                Description = "light rain",
                                Icon = "10d"},
                        },
                        Clouds = new Clouds(){
                            all = 100,},
                        Wind = new Wind(){
                            Speed = 3.74,
                            Deg = 301,
                            Gust =  3.74},
                        Visibility = 10000,
                        Pop = 1,
                        Dt_Txt = new DateTime(2022, 09, 23, 03, 0, 0)
                    },
                    new Lists(){
                        Dt = 119,
                        Main = new Main(){
                            Temp = 10.4,
                            Feels_Like = 12.91,
                            Temp_Min = 11.31,
                            Temp_Max = 13.4,
                            Pressure = 1009,
                            Sea_Level = 1009,
                            Grnd_Level = 1002,
                            Humidity = 81,
                            Temp_Kf  = 2.08},
                        Weather = new Weather[]{
                            new Weather() {
                                Id = 500,
                                Main = "Rain",
                                Description = "light rain",
                                Icon = "10d"},
                        },
                        Clouds = new Clouds(){
                            all = 100,},
                        Wind = new Wind(){
                            Speed = 3.74,
                            Deg = 301,
                            Gust =  3.74},
                        Visibility = 10000,
                        Pop = 1,
                        Dt_Txt = new DateTime(2022, 09, 23, 06, 0, 0)
                    },
                    new Lists(){
                        Dt = 120,
                        Main = new Main(){
                            Temp = 10.4,
                            Feels_Like = 12.91,
                            Temp_Min = 11.31,
                            Temp_Max = 13.4,
                            Pressure = 1009,
                            Sea_Level = 1009,
                            Grnd_Level = 1002,
                            Humidity = 81,
                            Temp_Kf  = 2.08},
                        Weather = new Weather[]{
                            new Weather() {
                                Id = 500,
                                Main = "Rain",
                                Description = "light rain",
                                Icon = "10d"},
                        },
                        Clouds = new Clouds(){
                            all = 100,},
                        Wind = new Wind(){
                            Speed = 3.74,
                            Deg = 301,
                            Gust =  3.74},
                        Visibility = 10000,
                        Pop = 1,
                        Dt_Txt = new DateTime(2022, 09, 23, 09, 0, 0)
                    },
                    new Lists(){
                        Dt = 121,
                        Main = new Main(){
                            Temp = 13.4,
                            Feels_Like = 12.91,
                            Temp_Min = 11.31,
                            Temp_Max = 13.4,
                            Pressure = 1009,
                            Sea_Level = 1009,
                            Grnd_Level = 1002,
                            Humidity = 81,
                            Temp_Kf  = 2.08},
                        Weather = new Weather[]{
                            new Weather() {
                                Id = 500,
                                Main = "Rain",
                                Description = "light rain",
                                Icon = "10d"},
                        },
                        Clouds = new Clouds(){
                            all = 100,},
                        Wind = new Wind(){
                            Speed = 3.74,
                            Deg = 301,
                            Gust =  3.74},
                        Visibility = 10000,
                        Pop = 1,
                        Dt_Txt = new DateTime(2022, 09, 23, 12, 0, 0)
                    },
                    new Lists(){
                        Dt = 122,
                        Main = new Main(){
                            Temp = 12.4,
                            Feels_Like = 12.91,
                            Temp_Min = 11.31,
                            Temp_Max = 13.4,
                            Pressure = 1009,
                            Sea_Level = 1009,
                            Grnd_Level = 1002,
                            Humidity = 81,
                            Temp_Kf  = 2.08},
                        Weather = new Weather[]{
                            new Weather() {
                                Id = 500,
                                Main = "Rain",
                                Description = "light rain",
                                Icon = "10d"},
                        },
                        Clouds = new Clouds(){
                            all = 100,},
                        Wind = new Wind(){ 
                            Speed = 3.74,
                            Deg = 301,
                            Gust =  3.74},
                        Visibility = 10000,
                        Pop = 1,
                        Dt_Txt = new DateTime(2022, 09, 23, 15, 0, 0)
                    },
                     new Lists(){
                        Dt = 123,
                        Main = new Main(){
                            Temp = 12.1,
                            Feels_Like = 11.56,
                            Temp_Min = 9.51,
                            Temp_Max = 12.1,
                            Pressure = 1011,
                            Sea_Level = 1011,
                            Grnd_Level = 1002,
                            Humidity = 84,
                            Temp_Kf  = 2.58},
                        Weather = new Weather[]{
                            new Weather() {
                                Id = 500,
                                Main = "Rain",
                                Description = "light rain",
                                Icon = "10d"},
                        },
                        Clouds = new Clouds(){
                            all = 100,},
                        Wind = new Wind(){
                            Speed = 2.94,
                            Deg = 291,
                            Gust =  6.85},
                        Visibility = 10000,
                        Pop = 1,
                        Dt_Txt = new DateTime(2022, 09, 23, 18, 0, 0)
                    },
                      new Lists(){
                        Dt = 123,
                        Main = new Main(){
                            Temp = 10.12,
                            Feels_Like = 9.51,
                            Temp_Min = 8.48,
                            Temp_Max = 10.12,
                            Pressure = 1012,
                            Sea_Level = 1012,
                            Grnd_Level = 1002,
                            Humidity = 89,
                            Temp_Kf  = 1.64},
                        Weather = new Weather[]{
                            new Weather() {
                                Id = 500,
                                Main = "Rain",
                                Description = "light rain",
                                Icon = "10d"},
                        },
                        Clouds = new Clouds(){
                            all = 100,},
                        Wind = new Wind(){
                            Speed = 2.92,
                            Deg = 300,
                            Gust =  6.65},
                        Visibility = 10000,
                        Pop = 1,
                        Dt_Txt = new DateTime(2022, 09, 23, 21, 0, 0)
                    },
                       new Lists(){
                        Dt = 123,
                        Main = new Main(){
                            Temp = 8.41,
                            Feels_Like = 6.6,
                            Temp_Min = 8.41,
                            Temp_Max = 8.41,
                            Pressure = 1013,
                            Sea_Level = 1013,
                            Grnd_Level = 1002,
                            Humidity = 91,
                            Temp_Kf  = 0},
                        Weather = new Weather[]{
                            new Weather() {
                                Id = 500,
                                Main = "Rain",
                                Description = "light rain",
                                Icon = "10d"},
                        },
                        Clouds = new Clouds(){
                            all = 95,},
                        Wind = new Wind(){
                            Speed = 3,
                            Deg = 290,
                            Gust = 7.75},
                        Visibility = 10000,
                        Pop = 1,
                        Dt_Txt = new DateTime(2022, 09, 24, 00, 0, 0)
                    }},
                City = new City() { 
                    Id = 12,
                    Name = "Podil",
                    Coord = new Coord() { 
                        Lat = 50.4755,
                        Lon = 30.5198},
                    Country = "",
                    Population = 0,
                    Timezone = 10800,
                    Sunrise = 1663904716,
                    Sunset = 1663948532}
                };

        }
        public async Task<IActionResult> Index()
        {
            ViewBag.TomorrowWeather = answerTomorrow.Data.Timelines[0];
            return View(answerTomorrow.Data.Timelines[0]);
        }
        public IActionResult About()
        {
            return View();
        }
        public async Task<IActionResult> TomorrowWeather()
        {

            await _eventProvider.AddTomorrowWeatherHistiry(answerTomorrow.Data.Timelines[0].Intervals);

            return View(answerTomorrow.Data.Timelines[0]);
        }
        public async Task<IActionResult> OpenWeatherWeather()
        {
            var date = await _apiService.GetWeatherByOpenWeatherAPIv25Bulk();

            var today = DateTime.Now.Day+1;

            var rangeTempToday = date.List.Where(list => list.Dt_Txt.Day == today).ToArray();

            await _eventProvider.AddOpenWeatherWeatherHistiry(rangeTempToday);

            return View(rangeTempToday);
        } 
    }
}