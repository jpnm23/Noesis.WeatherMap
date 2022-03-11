using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Noesis.WeatherMap.Data.Entities;
namespace Noesis.WeatherMap.Data.Repositories
{
    public interface IUserFavoritesRepository
    {
        IEnumerable<Favorite> GetUserFavorites(int id);

        void AddFavorite(Favorite favorite);

        Task<bool> SaveAllAsync();

    }
}
