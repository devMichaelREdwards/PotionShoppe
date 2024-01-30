using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class EmployeeAccount
{
    public int EmployeeAccountId { get; set; }

    public string? UserId { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }
}
