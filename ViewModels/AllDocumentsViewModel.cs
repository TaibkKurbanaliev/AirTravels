using AirTravels.Models;

namespace AirTravels.ViewModels
{
    public class AllDocumentsViewModel
    {
        public int Id { get; set; }
        public DocumentType? DocumentType { get; set; }
        public string? Number { get; set; }
    }
}
