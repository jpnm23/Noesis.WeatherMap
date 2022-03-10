using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Noesis.WeatherMap.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Noesis.WeatherMap.Data.Mapping
{
    public class FavoriteMap : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.HasKey(f => f.Id);
            builder.Property(f => f.Longitude).HasMaxLength(50).IsRequired();
            builder.Property(f => f.Latitude).HasMaxLength(50).IsRequired();
            builder.Property(f => f.City).HasMaxLength(100).IsRequired();
            builder.Property(f => f.Country).HasMaxLength(100).IsRequired();

            builder.HasOne(f => f.Users).WithMany(f => f.Favorites).HasForeignKey(f => f.UserId);
        }
    }
}
