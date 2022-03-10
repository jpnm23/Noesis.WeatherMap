using Microsoft.AspNetCore.Mvc;
using Noesis.WeatherMap.Data;
using Noesis.WeatherMap.Data.Controllers;
using Noesis.WeatherMap.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Noesis.WeatherMap.API.Controllers
{
    public class UsersController : Controller
    {
        public JsonResult GetUsers()
        {
            var newUsers = new UserController();
            var users = newUsers.GetUsers();

           return Json(users);
        }
    }
}
