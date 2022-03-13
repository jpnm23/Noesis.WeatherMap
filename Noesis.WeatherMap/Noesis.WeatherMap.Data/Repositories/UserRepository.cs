using Noesis.WeatherMap.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Noesis.WeatherMap.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
       
        public IEnumerable<User> GetUsers()
        {
            return _context.Users.OrderBy(u => u.Name).ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public bool UserExists(string name)
        {
            return _context.Users.Any(u => u.Name == name);
        }

        public bool VerifyUser(string name)
        {
            var getUsers = _context.Users;

            foreach (var item in getUsers)
            {
                int aux = Convert.ToInt32(Math.Floor(item.Name.Length * 0.8));
                string nameVerify = item.Name.Substring(0, aux);

                if (nameVerify.Contains(item.Name.Substring(0, nameVerify.Length)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
