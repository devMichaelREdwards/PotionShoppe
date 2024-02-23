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

    public int? EffectId { get; set; }
    public string? IngredientCategory { get; set; }

    public PotionEffectListing? Effect { get; set; }

    public static PotionEffectListing BuildIngredientEffect(Ingredient ingredient)
    {
        return new PotionEffectListing()
        {
            Title = ingredient.Effect!.Name,
            Color = ingredient.Effect.Color
        };
    }
}
