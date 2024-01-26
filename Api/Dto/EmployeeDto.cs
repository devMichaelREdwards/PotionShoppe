using System.Text.Json.Serialization;

namespace Api.Models;

public partial class EmployeeDto : IDto<Employee>
{
    public int? EmployeeId { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public string? Name { get; set; }
    public EmployeePositionDto? EmployeePosition { get; set; }
    public EmployeeStatusDto? EmployeeStatus { get; set; }
    public int? EmployeePositionId { get; set; }
    public int? EmployeeStatusId { get; set; }
    public DateOnly? DateHired { get; set; }
    public DateOnly? DateTerminated { get; set; }

    public bool Equals(Employee? other)
    {
        return other != null
            && other.EmployeeId == EmployeeId
            && other.Username == Username
            && other.Password == Password
            && other.Name == Name
            && other.EmployeeStatusId == EmployeeStatusId
            && other.EmployeePositionId == EmployeePositionId;
    }

    public void Update(Employee dest)
    {
        dest.Password = Password ?? dest.Password;
        dest.Name = Name ?? dest.Name;
        dest.EmployeeStatusId = EmployeeStatusId ?? dest.EmployeeStatusId;
        dest.EmployeePositionId = EmployeePositionId ?? dest.EmployeePositionId;
    }
}
