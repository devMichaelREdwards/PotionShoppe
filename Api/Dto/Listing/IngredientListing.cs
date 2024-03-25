namespace Api.Models;

public partial class IngredientListing
{
    public int? IngredientId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public int? Cost { get; set; }

    public int? CurrentStock { get; set; }

    public string? Image { get; set; }

    public string? IngredientCategory { get; set; }

    public EffectDisplayListing? Effect { get; set; }

    public static EffectDisplayListing BuildIngredientEffect(Ingredient ingredient)
    {
        return new EffectDisplayListing()
        {
            Title = ingredient.Effect!.Name,
            Color = ingredient.Effect.Color
        };
    }
}
