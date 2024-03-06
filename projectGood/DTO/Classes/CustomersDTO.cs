using System;
using System.Collections.Generic;

namespace DTO.Classes;

public class CustomerDTO
{
    public short CustId { get; set; }

    public string? CustFname { get; set; }

    public string? CustLname { get; set; }
    public string? CustPhone { get; set; }

    public string? CustEmail { get; set; }

    public string? CustPassword { get; set; }

    public bool? FirstAid { get; set; }

}
