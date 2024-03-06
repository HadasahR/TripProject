using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Type
{
    public short TypeId { get; set; }

    public string? TypeName { get; set; }

    public virtual ICollection<Trip> Trips { get; set; } = new List<Trip>();
}
