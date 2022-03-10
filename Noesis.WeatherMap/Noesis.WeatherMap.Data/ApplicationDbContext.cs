using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Noesis.WeatherMap.Data.Entities;
using Noesis.WeatherMap.Data.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Noesis.WeatherMap.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder builder)
        {
           

            builder.ApplyConfiguration(new UserMap());
            builder.ApplyConfiguration(new FavoriteMap());


        }

        

    }
}
