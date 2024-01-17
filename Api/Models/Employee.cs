namespace Api.Models;

public class Employee
{
    public int EmployeeId { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public required EmployeeStatus EmployeeStatusId { get; set; }
    public required EmployeePosition EmployeePositionId { get; set; }
}
