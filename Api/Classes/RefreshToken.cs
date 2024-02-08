namespace Api.Classes;

public class RefreshToken
{
    public required string Token { get; set; }
    public DateOnly Expire { get; set; }
}
