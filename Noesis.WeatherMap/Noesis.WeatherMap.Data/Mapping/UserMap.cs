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
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(f => f.Name).HasMaxLength(100).IsRequired();

            builder.HasMany(u => u.Favorites).WithOne(u => u.Users).HasForeignKey(u => u.UserId);
        }
    }
}
