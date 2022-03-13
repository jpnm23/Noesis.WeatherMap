using Noesis.WeatherMap.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace Noesis.WeatherMap.Data.Repositories
{
    public interface IUserFavoritesRepository
    {
        IEnumerable<Favorite> GetFavoritesByUser(int id);
        bool UserFavoriteExists(string city, string country, int id);
        void AddFavorite(Favorite favorite);
        void UpdateFavorite(Favorite favorite);
        Favorite GetFavorite(string city, string country, int id);
        Task<bool> SaveAllAsync();

    }
}
