using System;

namespace Project.AVIew.OtherAPI.Model.OpenWeather
{
    public class ResponsOpenWeatherAPI
    {
        public int Cod { get; set; }
        public string Message { get; set; }
        public string Cnt { get; set; }
        public Lists[] List { get; set; }
        public City City { get; set; }
    }
}