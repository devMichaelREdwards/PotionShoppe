
using Api.Classes;

namespace Api.Models;

public partial class EffectFilter : IFilter<Effect>
{
    public string? Name { get; set; }
    public int? ValueMin { get; set; }
    public int? ValueMax { get; set; }
    public int? DurationMin { get; set; }
    public int? DurationMax { get; set; }

    public List<int> Value { get; set; } = [];

    public dynamic? GetValue(string key)
    {
        return key switch
        {
            "name" => Name,
            "vmin" => ValueMin,
            "vmax" => ValueMax,
            "dmin" => DurationMin,
            "dmax" => DurationMax,
            "value" => Value,
            _ => null,
        };
    }

    public static EffectFilter? BuildFilter(IQueryCollection query)
    {
        if (query.Count == 0) return null;

        return new()
        {
            Name = ParseFilter.GetString("name", query),
            ValueMin = ParseFilter.GetInt("vmin", query),
            ValueMax = ParseFilter.GetInt("vmax", query),
            DurationMin = ParseFilter.GetInt("dmin", query),
            DurationMax = ParseFilter.GetInt("dmax", query),
            Value = ParseFilter.GetNumberOptions("value", query)
        };
    }
}
