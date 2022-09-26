using System.ComponentModel;

namespace Project.AVIew.EF.Enums
{
    public enum WeatherType
    {
        [Description("OpenWeather API system type")]
        OpenWeather = 0,
        [Description("Tomorrow API system type")]
        Tomorrow = 1,
    }
}
