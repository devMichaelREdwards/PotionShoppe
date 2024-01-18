namespace Api.Models;

public partial class Receipt
{
    public int ReceiptId { get; set; }

    public string? ReceiptNumber { get; set; }

    public int? EmployeeId { get; set; }

    public int? OrderId { get; set; }

    public DateOnly? DateFulfilled { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Order? Order { get; set; }
}
