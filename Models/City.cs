using System;
using System.Collections.Generic;

namespace AirTravels.Models;

public partial class City
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Ticket> TicketDeparturePointNavigations { get; set; } = new List<Ticket>();

    public virtual ICollection<Ticket> TicketDestinationNavigations { get; set; } = new List<Ticket>();
}
