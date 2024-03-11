using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class ReceiptDto : IDto<Receipt>
{
    public int? ReceiptId { get; set; }

    public string? ReceiptNumber { get; set; }

    public int? EmployeeId { get; set; }

    public int? OrderId { get; set; }

    public DateOnly? DateFulfilled { get; set; }

    public string? Employee { get; set; }

    public string? Order { get; set; }

    public bool Equals(Receipt? other)
    {
        return other != null
                && other.ReceiptNumber == ReceiptNumber
                && other.EmployeeId == EmployeeId
                && other.OrderId == OrderId;
    }

    public void Update(Receipt dest)
    {
        dest.DateFulfilled = DateFulfilled ?? dest.DateFulfilled;
    }
}
