using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeaterForecast.Models
{
    public class LocationWeatherResponse
    {
        public List<ConsolidatedWeatherResponse> consolidated_weather { get; set; }
    }
}
