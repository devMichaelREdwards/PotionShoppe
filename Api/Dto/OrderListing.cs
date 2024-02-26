using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class OrderListing
{
    public int? OrderId { get; set; }

    public string? OrderNumber { get; set; }

    public int? Total { get; set; }

    public DateOnly? DatePlaced { get; set; }

    public string? Customer { get; set; }

    public string? OrderStatus { get; set; }
}
