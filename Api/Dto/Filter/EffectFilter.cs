
using Api.Classes;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace Api.Models;

public partial class EffectFilter : IFilter<Effect>
{
    public string? Name { get; set; }
    public int? ValueMin { get; set; }
    public int? ValueMax { get; set; }
    public int? DurationMin { get; set; }
    public int? DurationMax { get; set; }

    public dynamic? GetValue(string key)
    {
        switch (key)
        {
            case "name": return Name;
            case "vmin": return ValueMin;
            case "vmax": return ValueMax;
            case "dmin": return DurationMin;
            case "dmax": return DurationMax;
            default: return null;
        }
    }

    public static EffectFilter BuildFilter(IQueryCollection query)
    {
        return new()
        {
            Name = ParseFilter.GetString("name", query),
            ValueMin = ParseFilter.GetInt("vmin", query),
            ValueMax = ParseFilter.GetInt("vmax", query),
            DurationMin = ParseFilter.GetInt("dmin", query),
            DurationMax = ParseFilter.GetInt("dmax", query)
        }; ;
    }
}
