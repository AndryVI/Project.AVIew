using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
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
    public class WeatherAPIController : ControllerBase
    {
        private readonly IAPIServices _apiService;
        private readonly IEventProvider _eventProvider;
        private readonly ILogger<WeatherController> _logger;


        public WeatherAPIController(ILogger<WeatherController> logger, IAPIServices apiService, IEventProvider eventProvider)
        {
            _logger = logger;
            _apiService = apiService;
            _eventProvider = eventProvider;
        }


      
        [HttpGet]
        [Route("GetWeatherByOpenWeatherAPIv25Bulk")]
        public async Task<IActionResult> GetWeatherByOpenWeatherAPIv25Bulk()
        {
            try
            {
                var respons = await _apiService.GetWeatherByOpenWeatherAPIv25Bulk();


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
        [Route("GetWeatherByOpenWeatherAPIv25Current")]
        public async Task<IActionResult> GetWeatherByOpenWeatherAPIv25Current()
        {
            try
            {
                var respons = await _apiService.GetWeatherByOpenWeatherAPIv25Current();


                if (respons == null)
                    return NotFound("bad request");

                //await _eventProvider.AddOpenWeatherWeatherHistiry(respons);

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
                var getAllLogoDevicesForUser = await _apiService.GetWeatherByOpenWeatherAPI(city);

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
                var json = await _apiService.GetWeatherByTomorrowAPI();

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
                var respons = await _apiService.PostWeatherByTomorrowAPI();

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
