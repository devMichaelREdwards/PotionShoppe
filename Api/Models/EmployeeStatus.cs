using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class EmployeeStatus
{
    public int EmployeeStatusId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
}
