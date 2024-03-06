using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Customer
{
    public short CustId { get; set; }

    public string? CustFname { get; set; }

    public string? CustLname { get; set; }

    public string? CustPhone { get; set; }

    public string? CustEmail { get; set; }

    public string? CustPassword { get; set; }

    public bool? FirstAid { get; set; }

    public virtual ICollection<OrderTicket> OrderTickets { get; set; } = new List<OrderTicket>();
}
