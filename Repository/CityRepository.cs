using AirTravels.Data;
using AirTravels.Interfaces;
using AirTravels.Models;
using Microsoft.EntityFrameworkCore;

namespace AirTravels.Repository
{
    public class CityRepository : IPropertyRepository<City>
    {
        private readonly AirTravelContext _context;

        public CityRepository(AirTravelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> GetById(int id)
        {
            return await _context.Cities.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
