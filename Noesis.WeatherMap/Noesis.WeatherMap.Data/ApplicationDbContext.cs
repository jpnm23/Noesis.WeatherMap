using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Noesis.WeatherMap.Data.Entities;
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
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(u => u.Name).HasMaxLength(100).IsRequired();

            modelBuilder.Entity<Favorite>().HasKey(f => f.Id);
            modelBuilder.Entity<Favorite>().Property(f => f.Longitude).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Favorite>().Property(f => f.Latitude).HasMaxLength(50).IsRequired();
            modelBuilder.Entity<Favorite>().Property(f => f.City).HasMaxLength(100).IsRequired();
            modelBuilder.Entity<Favorite>().Property(f => f.Country).HasMaxLength(100).IsRequired();

            base.OnModelCreating(modelBuilder);
        }

        

    }
}
