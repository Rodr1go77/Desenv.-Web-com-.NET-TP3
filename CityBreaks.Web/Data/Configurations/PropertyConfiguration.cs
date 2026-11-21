using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations
{
    public class PropertyConfiguration : IEntityTypeConfiguration<Property>
    {

        public void Configure(EntityTypeBuilder<Property> builder)
        {
            builder.Property(p => p.Name)
                .HasColumnName("nomePropriedade")
                .HasMaxLength(150);

            builder.HasData(

                new Property { Id = 1, CityId = 1, Name = "Hotel Nacional", PricePerNight = 500m },
                new Property { Id = 2, CityId = 2, Name = "Union Hotel", PricePerNight = 1000m },
                new Property { Id = 3, CityId = 3, Name = "Sotero Hotel", PricePerNight = 500m },
                new Property { Id = 4, CityId = 4, Name = "Minto 185", PricePerNight = 700m }

                );

        }

    }
}


