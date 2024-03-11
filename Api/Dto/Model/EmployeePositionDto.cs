namespace Api.Models;

public partial class EmployeePositionDto : IDto<EmployeePosition>
{
    public int? EmployeePositionId { get; set; }

    public string? Title { get; set; }

    public bool Equals(EmployeePosition? other)
    {
        return other?.EmployeePositionId == EmployeePositionId && other?.Title == Title;
    }

    public void Update(EmployeePosition dest)
    {
        dest.Title = Title;
    }
}
