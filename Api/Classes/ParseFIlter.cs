namespace Api.Classes;

public class ParseFilter
{
    public static string? GetString(string key, IQueryCollection query)
    {
        return query[key];
    }

    public static int? GetInt(string key, IQueryCollection query)
    {
        string? value = query[key];
        int parsedValue;


        if (!int.TryParse(value, out parsedValue))
        {
            // Failed parse
            return null;
        }

        return parsedValue;
    }
}
