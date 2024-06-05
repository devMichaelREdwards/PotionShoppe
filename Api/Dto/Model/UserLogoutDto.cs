namespace Api.Models;

public partial class UserLogoutDto // Does not need to implement IDto
{
    public string UserName { get; set; } = string.Empty;
}
