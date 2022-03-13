using Microsoft.AspNetCore.Mvc;
using Noesis.WeatherMap.Data.Repositories;
using System;
using Noesis.WeatherMap.Data.Entities;
using System.Threading.Tasks;
using Noesis.WeatherMap.API.Models;

namespace Noesis.WeatherMap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class UserFavoritesController : Controller
    {
        private readonly IUserFavoritesRepository _userFavHelper;
        private readonly IUserRepository _userHelper;

        public UserFavoritesController(IUserFavoritesRepository userFavHelper, IUserRepository userHelper)
        {
            _userFavHelper = userFavHelper;
            _userHelper = userHelper;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Route("GetFavoritesById")]
        [HttpGet]
        public IActionResult GetFavoritesById(int id)
        {
            var userFavorites = _userFavHelper.GetFavoritesByUser(id);
            return Ok(userFavorites);

        }

        [Route("AddUserFavorite")]
        [HttpPost]
        public async Task<IActionResult> AddFavorite(UserFavViewModel model)
        {
            if (_userFavHelper.UserFavoriteExists(model.City, model.Country, model.UserId))
            {
                var favoriteUpdate = _userFavHelper.GetFavorite(model.City, model.Country, model.UserId);
                favoriteUpdate.Longitude = model.Longitude;
                favoriteUpdate.Latitude = model.Latitude;

                _userFavHelper.UpdateFavorite(favoriteUpdate);
                await _userFavHelper.SaveAllAsync();
                return Ok(favoriteUpdate);
            }

            var user = _userHelper.GetUserById(model.UserId);
            Favorite favorite = new Favorite()
            {
                Longitude = model.Longitude,
                Latitude = model.Latitude,
                Country = model.Country,
                City = model.City,
                Users = user,
            };
            _userFavHelper.AddFavorite(favorite);
            await _userFavHelper.SaveAllAsync();
            return Ok(favorite);

        }


    }
}
