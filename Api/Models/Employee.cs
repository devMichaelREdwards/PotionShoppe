using System.Text.Json.Serialization;

namespace Api.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public int? EmployeeStatusId { get; set; }

    public int? PositionId { get; set; }

    public virtual EmployeeStatus? EmployeeStatus { get; set; }

    public virtual EmployeePosition? Position { get; set; }

    [JsonIgnore]
    public virtual ICollection<Potion> Potions { get; set; } = new List<Potion>();

    [JsonIgnore]
    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
