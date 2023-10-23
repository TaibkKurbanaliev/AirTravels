using System;
using System.Collections.Generic;

namespace AirTravels.Models;

public partial class Company
{
    public int Id { get; set; }

    public string Company1 { get; set; } = null!;

    public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
}
