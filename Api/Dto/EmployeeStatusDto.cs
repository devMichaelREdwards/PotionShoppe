namespace Api.Models;

public partial class EmployeeStatusDto : IDto<EmployeeStatus>
{
    public int? EmployeeStatusId { get; set; }

    public string? Title { get; set; }

    public bool Equals(EmployeeStatus? other)
    {
        return other?.EmployeeStatusId == EmployeeStatusId && other?.Title == Title;
    }

    public void Update(EmployeeStatus dest)
    {
        throw new NotImplementedException();
    }
}
