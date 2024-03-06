using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Trip
{
    public short TripId { get; set; }

    public string? Destination { get; set; }

    public short? TypeId { get; set; }

    public short? CustId { get; set; }

    public DateTime? Date { get; set; }

    public TimeSpan? LeavingHour { get; set; }

    public int? HowLong { get; set; }

    public int? EmptyPlaces { get; set; }

    public int? Price { get; set; }

    public string? Img { get; set; }

    public virtual ICollection<OrderTicket> OrderTickets { get; set; } = new List<OrderTicket>();

    public virtual Type? Type { get; set; }
}
