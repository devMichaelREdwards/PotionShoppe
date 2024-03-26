
using Api.Classes;

namespace Api.Models;

public partial class PotionFilter : IFilter<Potion>
{
    public string? Name { get; set; }
    public List<int>? Effects { get; set; }
    public int? CostMin { get; set; }
    public int? CostMax { get; set; }
    public int? PriceMin { get; set; }
    public int? PriceMax { get; set; }
    public bool? InStock { get; set; }
    public dynamic? GetValue(string key)
    {
        switch (key)
        {
            case "name": return Name;
            case "effect": return Effects;
            case "cmin": return CostMin;
            case "cmax": return CostMax;
            case "pmin": return PriceMin;
            case "pmax": return PriceMax;
            case "instock": return InStock;
            default: return null;
        }

    }

    public static PotionFilter BuildFilter(IQueryCollection query)
    {
        if (query.Count == 0) return null;

        return new()
        {
            Name = ParseFilter.GetString("name", query),
            Effects = ParseFilter.GetNumberOptions("effect", query),
            CostMin = ParseFilter.GetInt("cmin", query),
            CostMax = ParseFilter.GetInt("cmax", query),
            PriceMin = ParseFilter.GetInt("pmin", query),
            PriceMax = ParseFilter.GetInt("pmax", query),
            InStock = ParseFilter.GetBool("instock", query)
        };
    }
}
