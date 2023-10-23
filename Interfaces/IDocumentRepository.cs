using AirTravels.Models;

namespace AirTravels.Interfaces
{
    public interface IDocumentRepository
    {
        Task<IEnumerable<Document>> GetAll();
        Task<Document> GetById(int? id);
        bool Add(Document document);
        bool Update(Document document);
        bool Delete(Document document);
        bool Save();
    }
}
