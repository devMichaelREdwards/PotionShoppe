using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ReceiptListing
{
    public int? ReceiptId { get; set; }

    public string? ReceiptNumber { get; set; }

    public DateOnly? DateFulfilled { get; set; }

    public string? Employee { get; set; }

    public string? Customer { get; set; }
    public string? Order { get; set; }
}
