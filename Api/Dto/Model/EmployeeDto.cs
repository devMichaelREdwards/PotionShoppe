using System.Text.Json.Serialization;

namespace Api.Models;

public partial class EmployeeDto : IDto<Employee>
{
    public int? EmployeeId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
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
            && other.FirstName == FirstName
            && other.LastName == LastName
            && other.EmployeeStatusId == EmployeeStatusId
            && other.EmployeePositionId == EmployeePositionId;
    }

    public void Update(Employee dest)
    {
        dest.FirstName = FirstName ?? dest.FirstName;
        dest.LastName = LastName ?? dest.LastName;
        dest.EmployeeStatusId = EmployeeStatusId ?? dest.EmployeeStatusId;
        dest.EmployeePositionId = EmployeePositionId ?? dest.EmployeePositionId;
    }
}
