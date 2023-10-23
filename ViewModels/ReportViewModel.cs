using AirTravels.Models;

namespace AirTravels.ViewModels
{
    public class ReportViewModel
    {
        public IEnumerable<Passanger> Passangers { get; set; } = new List<Passanger>();
        public int PassangerId { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
    }
}
