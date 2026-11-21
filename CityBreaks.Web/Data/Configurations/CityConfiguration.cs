using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {

        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.Property(city => city.Name)
                .HasColumnName("nomeCidade")
                .HasMaxLength(150);

            builder.HasData(

                new City { Id = 1, CountryId = 1, Name = "Brasília" },
                new City { Id = 2, CountryId = 2, Name = "Toronto" },
                new City { Id = 3, CountryId = 1, Name = "Salvador" },
                new City { Id = 4, CountryId = 2, Name = "Ottawa" }

                );


        }


    }
}
