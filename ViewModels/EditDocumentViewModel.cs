using AirTravels.Models;

namespace AirTravels.ViewModels
{
    public class EditDocumentViewModel
    {
        public int Id { get; set; }
        public string? Type { get; set; }
        public int TypeId { get; set; }
        public IEnumerable<DocumentType> DocumentTypes { get; set; } = Enumerable.Empty<DocumentType>();
        public string? Number {  get; set; }
    }
}
