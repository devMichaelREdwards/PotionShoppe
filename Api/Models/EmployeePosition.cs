namespace Api.Models;

public partial class EmployeePosition
{
    public int EmployeePositionId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
