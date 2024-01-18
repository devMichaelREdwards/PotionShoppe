using System.Text.Json.Serialization;

namespace Api.Models;

public partial class EmployeeStatus
{
    public int EmployeeStatusId { get; set; }

    public string? Title { get; set; }

    [JsonIgnore]
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
