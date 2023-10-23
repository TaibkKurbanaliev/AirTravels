using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirTravels.Models;

public partial class Ticket
{
    public int Id { get; set; }

    public int DeparturePoint { get; set; }

    public int Destination { get; set; }

    public int OrderNumber { get; set; }

    public int ServiceProvider { get; set; }

    public DateOnly DepartureDate { get; set; }

    public DateOnly ArrivalDate { get; set; }

    public DateOnly ServiceRegistrationDate { get; set; }

    public int? Passanger { get; set; }

    public bool IsCompleted { get; set; }

    public virtual City DeparturePointNavigation { get; set; } = null!;

    public virtual City DestinationNavigation { get; set; } = null!;

    public virtual Passanger? PassangerNavigation { get; set; }

    public virtual Company ServiceProviderNavigation { get; set; } = null!;
}
