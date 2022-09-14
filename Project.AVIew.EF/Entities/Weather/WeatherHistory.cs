using System;
using System.ComponentModel.DataAnnotations;

namespace Project.AVIew.EF.Entities.Weather
{
    public class WeatherHistory
    {
        [Key]
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Service { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public double Temperature { get; set; }
        [Required]
        public double? Humidity { get; set; }
        [Required]
        public double? WindSpeed { get; set; }
    }
}
