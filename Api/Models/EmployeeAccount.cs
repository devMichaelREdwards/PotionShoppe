namespace Api.Models;

public partial class EmployeeAccount
{
    public required string EmployeeAccountId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
