using AirTravels.Models;

namespace AirTravels.ViewModels
{
    public class ShowPassangerByTicketVM
    {
        public int Id { get; set; }
        public string? SecondName { get; set; }
        public string? FirstName { get; set; }
        public string? ThirdName { get; set; }
        public int DocumentId { get; set; }
        public Document? Document { get; set; }
        public string? DocumentType { get; set; }
    }
}
