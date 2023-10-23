using AirTravels.Models;

namespace AirTravels.ViewModels
{
    public class TicketViewModel
    {
        public int Id { get; set; }
        public City? DeparturePoint { get; set; }
        public City? Destination { get; set; }
        public string? OrderNumber { get; set; }
        public Company? ServiceProvider { get; set; } 
        public string? DepartureDate { get; set; }
        public string? ArrivalDate { get; set; }
        public string? ServiceRegistrationDate { get; set; }
        public Passanger? Passanger { get; set; }
        public Document? Document { get; set; }
        public DocumentType? DocumentType { get; set; }
        public bool isCompleted { get; set; }
    }
}
