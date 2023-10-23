using System;
using System.Collections.Generic;

namespace AirTravels.Models;

public partial class Document
{
    public int Id { get; set; }

    public int Type { get; set; }

    public string Number { get; set; } = null!;

    public virtual ICollection<Passanger> Passangers { get; set; } = new List<Passanger>();

    public virtual DocumentType TypeNavigation { get; set; } = null!;
}
