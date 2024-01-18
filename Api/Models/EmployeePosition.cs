using System.Text.Json.Serialization;

namespace Api.Models;

public partial class EmployeePosition
{
    public int EmployeePositionId { get; set; }

    public string? Title { get; set; }

    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
