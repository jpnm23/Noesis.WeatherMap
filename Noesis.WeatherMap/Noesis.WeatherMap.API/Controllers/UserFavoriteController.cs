using Microsoft.AspNetCore.Mvc;
using Noesis.WeatherMap.Data.Repositories;
using System;
using Noesis.WeatherMap.Data.Entities;
using System.Threading.Tasks;

namespace Noesis.WeatherMap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class UserFavoriteController : Controller
    {
        private readonly IUserFavoritesRepository _userFavHelper;
        private readonly IUserRepository _userHelper;

        public UserFavoriteController(IUserFavoritesRepository userFavHelper, IUserRepository userHelper)
        {
            _userFavHelper = userFavHelper;
            _userHelper = userHelper;
        }

        [Route("GetUserFavorites")]
        [HttpGet]
        public IActionResult GetUserFavorites(int id)
        {
            var userFav = _userFavHelper.GetUserFavorites(id);

            if (userFav == null)
            {
                throw new ArgumentNullException("The list is empty!");
            }

            return Ok(userFav);
        }

        [Route("AddUserFavorite")]
        [HttpPost]
        public async Task<IActionResult> AddFavorite()
        {
            var user = _userHelper.GetUser(1);
            //string favorites = "{ 'id': 0,'longitude': '21312','latitude': '213', 'city': 'string', 'country': 'string', 'users: { 'id': 1, 'name': 'string'}}";
            Favorite favorite = new Favorite();
            favorite.Longitude = "teste";
            favorite.Latitude = "teste";
            favorite.Country = "PT";
            favorite.City = "aveiro";
            favorite.Users = user;


            _userFavHelper.AddFavorite(favorite);

            await _userHelper.SaveAllAsync();

            return Ok(favorite);

        }
    }
}
