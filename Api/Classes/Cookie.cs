namespace Api.Classes;
public class Cookie
{

    public static CookieOptions options = new()
    {
        HttpOnly = true,
        IsEssential = true,
        Secure = true,
        SameSite = SameSiteMode.None
    };
    public static CookieOptions GetOptions()
    {
        return options;
    }
}
