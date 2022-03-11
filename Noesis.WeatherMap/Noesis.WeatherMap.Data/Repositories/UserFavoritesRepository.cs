using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noesis.WeatherMap.Data.Entities;
namespace Noesis.WeatherMap.Data.Repositories
{

    public class UserFavoritesRepository : IUserFavoritesRepository
    {
        private readonly ApplicationDbContext _context;

        public UserFavoritesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Favorite> GetUserFavorites(int id)
        {
            return _context.Favorites.Where(u => u.Users.Id == id);           
        }

        public void AddFavorite(Favorite favorite)
        {
            _context.Favorites.Add(favorite);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
