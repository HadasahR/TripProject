using System;
using System.Collections.Generic;

namespace DTO.Classes;

public  class OrderTicketDTO
{
    public short OrdId { get; set; }

    public short? CustId { get; set; }

    public DateTime? OrdDate { get; set; }

    public TimeSpan? OrdTime { get; set; }

    public short? TripId { get; set; }

    public int? CountPlaces { get; set; }
    //תוספת מהמסד שדה של שם פרטי ומשפחה של הלקוח
    public string? customerFullName { get; set; }
    //תוספת של יעד הטיול מלבד קוד הטיול 
    public string Destination { get; set; }
    //תוספת של תאריך הטיול 
    public DateTime TripDate { get; set; }
}
