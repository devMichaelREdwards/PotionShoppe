using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class EmployeeAccount
{
    public int EmployeeAccountId { get; set; }

    public string? UserName { get; set; }

    public int? EmployeeId { get; set; }

    public string? RefreshToken { get; set; }

    public DateOnly? TokenExpire { get; set; }
    public string? Email { get; set; }

    public virtual Employee? Employee { get; set; }
}
