using AirTravels.Models;

namespace AirTravels.ViewModels
{ 
    public class AllPassangerViewModel
    {
        public int Id { get; set; }
        public string? SecondName { get; set; } 
        public string? FirstName { get; set; }
        public string? ThirdName { get; set; }
        public Document? Document { get; set; }
        public DocumentType? DocumentType { get; set; }
    }
}
