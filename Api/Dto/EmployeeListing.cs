using System.Text.Json.Serialization;

namespace Api.Models;

public partial class EmployeeListing
{
    public int? EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? EmployeePosition { get; set; }
    public string? EmployeeStatus { get; set; }
    public string? UserName { get; set; }
}
