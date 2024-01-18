using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }
    public DateOnly? DateHired { get; set; }
    public DateOnly? DateTerminated { get; set; }

    public int? EmployeeStatusId { get; set; }

    public int? EmployeePositionId { get; set; }

    public virtual EmployeePosition? EmployeePosition { get; set; }

    public virtual EmployeeStatus? EmployeeStatus { get; set; }

    public virtual ICollection<Potion> Potions { get; set; } = new List<Potion>();

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
