using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeaterForecast.Helpers;
using WeaterForecast.Models;

namespace WeaterForecast.Sevices
{
    public class WeatherForecastService: IWeatherForecastService
    {
        public int GetLocationId(string locationName)
        {
            var response = HttpRequestHelper.GetRequest($"https://www.metaweather.com/api/location/search/?query={locationName}");

            var result = JsonConvert.DeserializeObject<List<LocationResponse>>(response);
            return result.FirstOrDefault().woeid;
        }

        public List<ConsolidatedWeatherResponse> GetLocationWeatherForecast(int weid)
        {
            var response = HttpRequestHelper.GetRequest($"https://www.metaweather.com/api/location/{weid}");

            var result = JsonConvert.DeserializeObject<LocationWeatherResponse> (response);
            return result.consolidated_weather.Take(5).ToList();
        }
    }
}
