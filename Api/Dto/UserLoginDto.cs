namespace Api.Models;

public partial class UserLoginDto // Does not need to implement IDto
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
