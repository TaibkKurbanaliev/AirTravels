using AirTravels.Models;

namespace AirTravels.ViewModels
{
    public class EditTicketViewModel
    {
        public int Id { get; set; }
        public string? DeparturePoint { get; set; }
        public int DeparturePointId { get; set; }
        public string? Destination { get; set; }
        public int DestinationId { get; set; }
        public IEnumerable<City> Cities { get; set; } = Enumerable.Empty<City>();
        public int OrderNumber { get; set; }
        public string? ServiceProvider { get; set; }
        public int ServiceProviderId { get; set; }
        public IEnumerable<Company> Companies { get; set; } = Enumerable.Empty<Company>();
        public string? DepartureDate { get; set; }
        public string? ArrivalDate { get; set; }
        public string? ServiceRegistrationDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
