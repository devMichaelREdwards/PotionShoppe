using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Ingredient
{
    public int IngredientId { get; set; }

    public int? EffectId { get; set; }

    public int? IngredientCategoryId { get; set; }

    public int? ProductId { get; set; }

    public virtual Effect? Effect { get; set; }

    public virtual IngredientCategory? IngredientCategory { get; set; }

    public virtual Product? Product { get; set; }
}
