using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class IngredientCategory
{
    public int IngredientCategoryId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
}
