namespace Api.Classes;

public class Jwt
{
    public required bool Success { get; set; }
    public required string Token { get; set; }
    public required string[] Roles { get; set; }
}
