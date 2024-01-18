namespace Api.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public int? Cost { get; set; }

    public int? CurrentStock { get; set; }

    public int? Image { get; set; }

    public int? EffectId { get; set; }

    public virtual Effect? Effect { get; set; }
}
