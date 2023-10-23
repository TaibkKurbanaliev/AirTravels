using AirTravels.Models;

namespace AirTravels.ViewModels
{
    public class CreateTicketViewModel
    {
        public int Id { get; set; }

        public IEnumerable<City> DeparturePoints { get; set; } = new List<City>();

        public int DeparturePointId { get; set; }

        public IEnumerable<City> Destinations { get; set; } = new List<City>();

        public int DestinationId { get; set; }

        public int OrderNumber { get; set; }

        public IEnumerable<Company> ServiceProviders { get; set; } = new List<Company>();

        public int ServiceProviderId { get; set; }

        public string DepartureDate { get; set; }

        public string ArrivalDate { get; set; }

        public string ServiceRegistrationDate { get; set; }

        public IEnumerable<Passanger> Passangers { get; set; } = new List<Passanger>();
        public int PassangerId { get; set; }

        public bool IsCompleted { get; set; }
    }
}
