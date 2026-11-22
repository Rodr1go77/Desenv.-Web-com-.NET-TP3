using CityBreaks.Web.Data;
using CityBreaks.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace CityBreaks.Web.Services
{
    public class PropertyService
    {
        private readonly CityBreaksContext _context;

        public PropertyService (CityBreaksContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync (int id)
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


    }
}
