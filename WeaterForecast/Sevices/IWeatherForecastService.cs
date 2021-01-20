using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeaterForecast.Models;

namespace WeaterForecast.Sevices
{
    public interface IWeatherForecastService
    {
        int GetLocationId(string locationName);
        List<ConsolidatedWeatherResponse> GetLocationWeatherForecast(int weid);
    }
}
