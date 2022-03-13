using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Noesis.WeatherMap.API.Models;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Noesis.WeatherMap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeathersController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> Get(string coordinate)
        {
            if (coordinate == null)
            {
                return NotFound();
            }

            string[] vs = coordinate.Split(',');
            string lat = vs[0].Replace("(", "");
            string lng = vs[1].Replace(")", "").Replace(" ", "");

            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://community-open-weather-map.p.rapidapi.com/weather?lat=" + lat + "&lon=" + lng + "&lang=pt&units=metric"),
                Headers =
                {
                    { "x-rapidapi-host", "community-open-weather-map.p.rapidapi.com" },
                    { "x-rapidapi-key", "39e0a6feccmsh8c83bdcbaf17cdap18330ajsn1e5e8950bccf" },
                },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var jWeather = JsonConvert.DeserializeObject<dynamic>(body);
                var weather = new WeatherViewModel()
                {
                    Lat = jWeather.coord.lat,
                    Lon = jWeather.coord.lon,
                    Temp = jWeather.main.temp,
                    Description = jWeather.weather[0].description,
                    FeelsLike = jWeather.main.feels_like,
                    Humidity = jWeather.main.humidity,
                    Wind = jWeather.wind.speed,
                    City = jWeather.name,
                    Country = jWeather.sys.country,
                };

                return Ok(weather);
            }
        }
    }
}
