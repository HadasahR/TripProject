using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class OrderTicket
{
    public short OrdId { get; set; }

    public short? CustId { get; set; }

    public DateTime? OrdDate { get; set; }

    public TimeSpan? OrdTime { get; set; }

    public short? TripId { get; set; }

    public int? CountPlaces { get; set; }

    public virtual Customer? Cust { get; set; }

    public virtual Trip? Trip { get; set; }
}
