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
                throw new ArgumentNullException("The list is empty!");
            }

            return Ok(users);
        }

        [Route("AddUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest(new { message = "Not valid!" });
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

        [Route("GetUserByName")]
        [HttpGet]
        public IActionResult GetUser(string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            if (!_userHelper.UserExists(name))
            {
                return NotFound();
            }
            var user = _userHelper.GetUser(name);

            if (user == null)
            {
                throw new ArgumentNullException("User is null!");
            }
            return Ok(user);
        }
    }
}
