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

    public static List<string> GetStringOptions(string key, IQueryCollection query)
    {
        string? value = query[key];

        return value.Split("|").ToList();
    }

    public static List<int> GetNumberOptions(string key, IQueryCollection query)
    {
        string? value = query[key];
        string[] values = value.Split("|");

        List<int> ret = [];

        int parsedValue;
        foreach (string v in values)
        {
            if (!int.TryParse(v, out parsedValue))
            {
                // Failed parse
                return null;
            }

            ret.Add(parsedValue);
        }

        return ret;
    }
}
