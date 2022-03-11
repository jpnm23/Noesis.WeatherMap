using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Noesis.WeatherMap.API.Controllers
{
    



    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class WeatherController
    {
        public WeatherController()
        {

        }

        [Route("GetCurrentWeather")]
        [HttpGet]
        public async Task<dynamic> GetCurrentWeather(string latitude, string longitude)
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage response = await client.GetAsync("https://api.openweathermap.org/data/2.5/weather?lat=" + latitude + "&lon=" + longitude + "&appid=4fe9e4228ad778bc2449ab3782d6dcd7");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                return result;
            }
            
            return null;
        }
    }
}
