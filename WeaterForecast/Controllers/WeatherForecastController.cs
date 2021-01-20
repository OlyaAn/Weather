using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WeaterForecast.Models;
using WeaterForecast.Sevices;

namespace WeaterForecast.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IWeatherForecastService _service;

        public WeatherForecastController(IWeatherForecastService service)
        {
            _service = service;
        }

        [HttpGet("Location/{locationName}")]
        public ActionResult<int> GetLocationId(string locationName)
        {
            var id = _service.GetLocationId(locationName);
            return Ok(id);
        }

        [HttpGet("locationWeather/{locationId}")]
        public ActionResult<ConsolidatedWeatherResponse> GetLocationWeatherForecast(int locationId)
        {
            var result = _service.GetLocationWeatherForecast(locationId);
            return Ok(result);
        }
    }
}
