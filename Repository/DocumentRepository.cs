using AirTravels.Data;
using AirTravels.Interfaces;
using AirTravels.Models;
using Microsoft.EntityFrameworkCore;

namespace AirTravels.Repository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AirTravelContext _context;

        public DocumentRepository(AirTravelContext context)
        {
            _context = context;
        }

        public bool Add(Document document)
        {
            _context.Add(document);
            return Save();
        }

        public bool Delete(Document document)
        {
            _context.Remove(document);
            return Save();
        }

        public async Task<IEnumerable<Document>> GetAll()
        {
            return await _context.Documents.ToListAsync();
        }

        public async Task<Document> GetById(int? id)
        {
            return await _context.Documents.FirstOrDefaultAsync(document => document.Id == id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public bool Update(Document document)
        {
            _context.Update(document);
            return Save();
        }
    }
}
