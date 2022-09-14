using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Project.AVIew.Model;
using System.Threading.Tasks;
using Project.AVIew.OtherAPI.Services;
using OpenWeatherAPI;
using Newtonsoft.Json;
using Project.AVIew.OtherAPI.Model.Tomorrow;
using Microsoft.AspNetCore.Authorization;
using Project.AVIew.Services;

namespace Project.AVIew.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IAPIServices _repository;
        private readonly IEventProvider _eventProvider;
        private readonly ILogger<WeatherForecastController> _logger;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

      


        public WeatherForecastController(ILogger<WeatherForecastController> logger, IAPIServices repository, IEventProvider eventProvider)
        {
            _logger = logger;
            _repository = repository;
            _eventProvider = eventProvider;
        }

        [HttpGet, Authorize]
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

        [HttpGet]
        [Route("GetWeatherByOpenWeatherAPIv25")]
        public async Task<IActionResult> GetWeatherByOpenWeatherAPIv25()
        {
            try
            {
                var respons = await _repository.GetWeatherByOpenWeatherAPIv25();


                if (respons == null)
                    return NotFound("bad request");

                await _eventProvider.AddOpenWeatherWeatherHistiry(respons.List);

                return Ok(respons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetOpenWeatherAPIByNuget")]
        public async Task<IActionResult> GetOpenWeatherAPIByNuget(string city)
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
                    return NotFound("bad request");

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
        [Produces(typeof(ResponsTomorrowAPI))]
        public async Task<IActionResult> PostTomorrowAPI()
        {
            try
            {
                var respons = await _repository.PostWeatherByTomorrowAPI();

                if (respons == null)
                    return NotFound("bad request");

                await _eventProvider.AddTomorrowWeatherHistiry(respons.Data.Timelines[0].Intervals);

                return Ok(respons);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
