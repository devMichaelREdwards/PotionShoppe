using System;
using System.Collections.Generic;
using System.IO.Pipelines;

namespace Api.Models;

public partial class EmployeeRegistrationDto // Does not need to implement IDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
