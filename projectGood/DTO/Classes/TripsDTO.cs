using System;
using System.Collections.Generic;

namespace DTO.Classes;

public  class TripDTO
{
    public short TripId { get; set; }

    public string? Destination { get; set; }

    public short? TypeId { get; set; }
    //תוספת של שם סוג מלבד קוד סוג
    public string? TypeName { get; set; }
    //?????????????????????????????
    public short? CustId { get; set; }
    public DateTime? Date { get; set; }
    public TimeSpan? LeavingHour { get; set; }
    public int? HowLong { get; set; }
    public int? EmptyPlaces { get; set; }

    public int? Price { get; set; }

    public string? Img { get; set; }
    //תוספת של שדה האם צריך תעודת עזרה ראשונה או שיש כבר 
    public bool? IsFirstAid { get; set; } = false;
}
