using Microsoft.AspNetCore.Mvc;
using Noesis.WeatherMap.Data.Entities;
using Noesis.WeatherMap.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Noesis.WeatherMap.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Consumes("application/json")]
    public class UsersController : Controller
    {
        private readonly IUserRepository _userHelper;

        public UsersController(IUserRepository userHelper)
        {
            _userHelper = userHelper;
        }

        [Route("GetUsers")]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userHelper.GetUsers();

            if (users == null)
            {
                return BadRequest();
            }

            return Ok(users);
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest(new { message = "String null" });
            }
            if (_userHelper.UserExists(name))
            {
                return BadRequest();
            }

            var user = new User()
            {
                Name = name,
            };

            _userHelper.AddUser(user);
            await _userHelper.SaveAllAsync();

            return Ok(user);
        }

    }
}
