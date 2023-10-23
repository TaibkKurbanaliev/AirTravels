using AirTravels.Models;

namespace AirTravels.ViewModels
{
    public class CreatePassangerViewModel
    {
        public int Id { get; set; }
        public string SecondName {  get; set; }
        public string FirstName { get; set; }
        public string ThirdName { get; set; }

        public Document? Document { get; set; } = new Document();
        public IEnumerable<DocumentType>? DocumentTypes { get; set; } = new List<DocumentType>();
    }
}
