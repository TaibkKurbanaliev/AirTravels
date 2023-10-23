using System;
using System.Collections.Generic;

namespace AirTravels.Models;

public partial class Passanger
{
    public int Id { get; set; }

    public string SecondName { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string ThirdName { get; set; } = null!;

    public int? Document { get; set; }

    public virtual Document? DocumentNavigation { get; set; }

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
