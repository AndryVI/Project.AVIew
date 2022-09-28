using Project.AVIew.OtherAPI.Model.Tomorrow;
using System;

namespace Project.AVIew.Model
{
    public class ComparisonsWeatherAPI
    {
        public double TemperatureTomorrow { get; set; }
        public WeatherCodes? CodTomorrow { get; set; }
        public double TemperatureOpenWeather { get; set; }
        public string? CodOpenWeather { get; set; }
        public DateTime Time { get; set; }
    }
}
