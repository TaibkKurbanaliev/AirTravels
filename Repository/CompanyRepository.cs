using AirTravels.Data;
using AirTravels.Interfaces;
using AirTravels.Models;
using Microsoft.EntityFrameworkCore;

namespace AirTravels.Repository
{
    public class CompanyRepository : IPropertyRepository<Company>
    {
        private readonly AirTravelContext _context;

        public CompanyRepository(AirTravelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Company>> GetAll()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company> GetById(int id)
        {
            return await _context.Companies.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
