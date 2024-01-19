using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class EmployeeDto
{
    public int EmployeeId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }
    public string EmployeePosition { get; set; } = String.Empty;
    public string EmployeeStatus { get; set; } = String.Empty;
    public DateOnly? DateHired { get; set; }
    public DateOnly? DateTerminated { get; set; }
}
