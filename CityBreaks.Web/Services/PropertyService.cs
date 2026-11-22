using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Services
{
    public class PropertyService
    {
        private readonly CityBreaksContext _context;

        public PropertyService(CityBreaksContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(int id)
        {
            var property = await _context.Properties.FindAsync(id);

            if (property is null)
            {
                return;
            }

            property.DeletedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

        }

        public async Task<List<Property>> ListarPropertiesAtivas()
        {
            return await _context.Properties
                .Where(p => p.DeletedAt == null)
                .ToListAsync();

        }

        public async Task<List<Property>> GetFilteredAsync(decimal? minPrice, decimal? maxPrice, string? cityName, string? propertyName)
        {
            IQueryable<Property> query = _context.Properties
                .Include(p => p.City)
                .Where(p => p.DeletedAt == null);

            if (minPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight >= minPrice.Value);
            }

            if (maxPrice.HasValue)
            {
                query = query.Where(p => p.PricePerNight <= maxPrice.Value);
            }

            if (!string.IsNullOrWhiteSpace(cityName))
            {
                var cidadeBusca = cityName.Trim();
                query = query.Where(p => p.Name != null && p.City.Name == cidadeBusca);
            }

            if (!string.IsNullOrWhiteSpace(propertyName))
            {
                query = query.Where(p => p.Name.Contains(propertyName.Trim()));
            }

            return await query.ToListAsync();


        }

    }
}
