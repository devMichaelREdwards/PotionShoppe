namespace Api.Models;

public partial class EmployeePositionDto : IDto<EmployeePositionDto>
{
    public int? EmployeePositionId { get; set; }

    public string? Title { get; set; }

    public bool Equals(EmployeePositionDto? other)
    {
        return other?.EmployeePositionId == EmployeePositionId && other?.Title == Title;
    }
}
