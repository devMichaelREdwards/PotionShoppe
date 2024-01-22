namespace Api.Models;

public partial class EmployeeStatusDto : IDto<EmployeeStatusDto>
{
    public int? EmployeeStatusId { get; set; }

    public string? Title { get; set; }

    public bool Equals(EmployeeStatusDto? other)
    {
        return other?.EmployeeStatusId == EmployeeStatusId && other?.Title == Title;
    }
}
