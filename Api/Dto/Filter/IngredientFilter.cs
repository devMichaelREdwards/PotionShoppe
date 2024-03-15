
using Api.Classes;

namespace Api.Models;

public partial class IngredientFilter : IFilter<Ingredient>
{
    public string? Name { get; set; }
    public int? IngredientCategoryId { get; set; }
    public int? EffectId { get; set; }
    public dynamic? GetValue(string key)
    {
        switch (key)
        {
            case "name": return Name;
            case "category": return IngredientCategoryId;
            case "effect": return EffectId;
            default: return null;
        }

    }

    public static IngredientFilter BuildFilter(IQueryCollection query)
    {
        if (query.Count == 0) return null;

        return new()
        {
            Name = ParseFilter.GetString("name", query),
            IngredientCategoryId = ParseFilter.GetInt("category", query),
            EffectId = ParseFilter.GetInt("effect", query)
        };
    }
}
