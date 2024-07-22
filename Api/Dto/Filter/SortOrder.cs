
using Api.Classes;

namespace Api.Models;

public partial class SortOrder : IFilter<SortOrder>
{
    public string? Sort { get; set; }
    public string? Order { get; set; }

    public dynamic? GetValue(string key)
    {
        return key switch
        {
            "sort" => Sort,
            "order" => Order,
            _ => null,
        };
    }

    public static SortOrder? BuildFilter(IQueryCollection query)
    {
        if (query.Count == 0) return null;

        return new()
        {
            Sort = ParseFilter.GetString("sort", query) ?? "",
            Order = ParseFilter.GetString("order", query) ?? "",
        };
    }
}
