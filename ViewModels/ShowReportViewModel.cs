namespace AirTravels.ViewModels
{
    public class ShowReportViewModel
    {
        public int Id { get; set; }
        public DateOnly ServiceRegistrationDate { get; set; }
        public DateOnly ArrivalDate { get; set; }
        public string? OrderNumber { get; set; }
        public string? DeparturePoint { get; set; }
        public string? Destination { get; set; }
        public bool IsCompleted { get; set; }
    }
}
