using System;
using System.Collections.Generic;
using System.IO.Pipelines;

namespace Api.Models;

public partial class UserLoginDto // Does not need to implement IDto
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
