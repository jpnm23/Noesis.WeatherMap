using Noesis.WeatherMap.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Noesis.WeatherMap.Data.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user);
        User GetUser(string name);
        IEnumerable<User> GetUsers();
        Task<bool> SaveAllAsync();
        bool UserExists(string name);
    }
}