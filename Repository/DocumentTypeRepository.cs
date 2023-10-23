using AirTravels.Data;
using AirTravels.Interfaces;
using AirTravels.Models;
using Microsoft.EntityFrameworkCore;

namespace AirTravels.Repository
{
    public class DocumentTypeRepository : IPropertyRepository<DocumentType>
    {
        private readonly AirTravelContext _context;

        public DocumentTypeRepository(AirTravelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<DocumentType>> GetAll()
        {
            return await _context.DocumentTypes.ToListAsync();
        }

        public async Task<DocumentType> GetById(int id)
        {
            return await _context.DocumentTypes.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
