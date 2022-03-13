using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Noesis.WeatherMap.Site.Models;
using System;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Noesis.WeatherMap.Site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Favorite()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44368/Users/GetUsers")
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return Json(body);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(string name)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:44368/Users/AddUser?name=" + name)
            };
            using (var response = await client.SendAsync(request))
            {
                try
                {
                    response.EnsureSuccessStatusCode();
                    var body = await response.Content.ReadAsStringAsync();
                    return Json(body);
                }
                catch (Exception e)
                {

                    return Json(e.Message);
                }

            }
        }

        [HttpGet]
        public async Task<IActionResult> GetWeatherByMark(string location)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44368/Weathers?coordinate=" + location)
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return Json(body);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddUserFav(UserFavViewModel viewModel)
        {

            // Serialize our concrete class into a JSON String
            var stringPayload = JsonConvert.SerializeObject(viewModel);

            // Wrap our JSON inside a StringContent which then can be used by the HttpClient class
            var httpContent = new StringContent(stringPayload, Encoding.UTF8, "application/json");

            var httpClient = new HttpClient();

            // Do the actual request and await the response
            var httpResponse = await httpClient.PostAsync("https://localhost:44368/UserFavorites/AddUserFavorite", httpContent);

            // If the response contains content we want to read it!
            if (httpResponse.Content != null)
            {
                var responseContent = await httpResponse.Content.ReadAsStringAsync();

                return Json(responseContent);
                // From here on you could deserialize the ResponseContent back again to a concrete C# type using Json.Net
            }

            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserFavorites(int id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44368/UserFavorites/GetFavoritesById?id=" + id)
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();

                return Json(body);
            }
        }

    }
}
