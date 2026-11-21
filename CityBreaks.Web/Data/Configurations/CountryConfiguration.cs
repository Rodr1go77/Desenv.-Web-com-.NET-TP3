using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations
{

    public class CountryConfiguration : IEntityTypeConfiguration <Country>
    {

        public void Configure (EntityTypeBuilder<Country> builder)
        {
            builder.Property(c => c.CountryName)
                .HasColumnName("nomePais")
                .HasMaxLength(150);

            builder.HasData(
                new Country { Id = 1, CountryName = "Brasil" },
                new Country { Id = 2, CountryName = "Canadá" }
                );

        }

    }
}

