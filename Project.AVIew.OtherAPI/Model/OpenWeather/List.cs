using System;

namespace Project.AVIew.OtherAPI.Model.OpenWeather
{
    public class Lists
    {
        public int Dt { get; set; }
        public Main Main { get; set; }
        public Weather[] Weather { get; set; }
        public Clouds Clouds { get; set; }
        public Wind Wind { get; set; }
        public int Visibility { get; set; }
        public double Pop { get; set; }
        public Sys Sys { get; set; }
        public DateTime DtTxt { get; set; }
    }

    public class Main
    {
        public string Temp { get; set; }
        public string Feels_Like { get; set; }
        public string Temp_Min { get; set; }
        public string Temp_Max { get; set; }
        public int Pressure { get; set; }
        public int Sea_Level { get; set; }
        public int Grnd_Level { get; set; }
        public double Humidity { get; set; }
        public double Temp_Kf { get; set; }
    }

    public class Weather
    {
        public int Id { get; set; }
        public string Main { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
    public class Clouds
    {
        public int all { get; set; }
    }
    public class Wind
    {
        public double Speed { get; set; }
        public double Deg { get; set; }
        public double Gust { get; set; }
    }
    public class Sys
    {
        public string Pod { get; set; }
    }
}
