using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? EmployeeStatusId { get; set; }

    public int? EmployeePositionId { get; set; }

    public virtual EmployeePosition? EmployeePosition { get; set; }

    public virtual EmployeeStatus? EmployeeStatus { get; set; }

    public virtual ICollection<Potion> Potions { get; set; } = new List<Potion>();

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
