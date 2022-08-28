using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Project.AVIew.Model;
using System.Threading.Tasks;
using Project.AVIew.OtherAPI;
using OpenWeatherAPI;
using Newtonsoft.Json;
using Project.AVIew.Model;

namespace Project.AVIew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepository _repository;
        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpPost]
        [Route("OpenWeatherAPI")]
        [Produces(typeof(QueryResponse))]
        public async Task<IActionResult> OpenWeatherAPI(string city)
        {
            try
            {
                var getAllLogoDevicesForUser = await _repository.GetWeatherByOpenWeatherAPI(city);

                if (getAllLogoDevicesForUser == null)
                    return NotFound("city - notFound");
                return Ok(getAllLogoDevicesForUser);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetTomorrowAPI")]
        public async Task<IActionResult> GetTomorrowAPI()
        {
            try
            {
                var json = await _repository.GetWeatherByTomorrowAPI();

                if (json == null)
                    return NotFound("bad requset");

                var yourClass = JsonConvert.DeserializeObject<ResponsTomorrowAPI>(json.Content);

                return Ok(yourClass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("PostTomorrowAPI")]
        public async Task<IActionResult> PostTomorrowAPI()
        {
            try
            {
                var json = await _repository.PostWeatherByTomorrowAPI();

                if (json == null)
                    return NotFound("bad requset");

                var yourClass = JsonConvert.DeserializeObject<ResponsTomorrowAPI>(json.Content);

                return Ok(yourClass);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
