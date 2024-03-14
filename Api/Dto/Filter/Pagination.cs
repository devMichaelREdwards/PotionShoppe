
using Api.Classes;

namespace Api.Models;

public partial class Pagination : IFilter<Pagination>
{
    public int? Page { get; set; }
    public int? Limit { get; set; }

    public dynamic? GetValue(string key)
    {
        switch (key)
        {
            case "page": return Page;
            case "limit": return Limit;
            default: return null;
        }
    }

    public static Pagination? BuildFilter(IQueryCollection query)
    {
        if (query.Count == 0) return null;

        return new()
        {
            Page = ParseFilter.GetInt("page", query) ?? 1,
            Limit = ParseFilter.GetInt("limit", query) ?? 20,
        };
    }
}
