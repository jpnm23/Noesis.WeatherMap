using Microsoft.EntityFrameworkCore;
using Noesis.WeatherMap.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Noesis.WeatherMap.Data.Repositories
{

    public class UserFavoritesRepository : IUserFavoritesRepository
    {
        private readonly ApplicationDbContext _context;

        public UserFavoritesRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Favorite> GetFavoritesByUser(int id)
        {
            return _context.Favorites.Include(u => u.Users).Where(favorite => favorite.Users.Id == id);
        }

        public bool UserFavoriteExists(string city, string country, int id)
        {
            return _context.Favorites.Any(Favorite =>
            Favorite.City == city &&
            Favorite.Country == country &&
            Favorite.Users.Id == id);
        }

        public void UpdateFavorite(Favorite favorite)
        {
            _context.Favorites.Update(favorite);
        }

        public void AddFavorite(Favorite favorite)
        {
            _context.Favorites.Add(favorite);

        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public Favorite GetFavorite(string city, string country, int id)
        {
            return _context.Favorites.Include(u => u.Users)
                .FirstOrDefault(Favorite =>
            Favorite.City == city &&
            Favorite.Country == country &&
            Favorite.Users.Id == id);
        }
    }
}
