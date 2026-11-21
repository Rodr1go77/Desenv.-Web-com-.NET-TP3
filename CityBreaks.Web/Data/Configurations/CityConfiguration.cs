using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CityBreaks.Web.Data.Configurations
{
    public class CityConfiguration : IEntityTypeConfiguration <City>
    {
        
        public void Configure (EntityTypeBuilder<City> builder)
        {
            builder.Property(city => city.Name)
                .HasColumnName("nomeCidade")
                .HasMaxLength(150);
        }


    }
}
