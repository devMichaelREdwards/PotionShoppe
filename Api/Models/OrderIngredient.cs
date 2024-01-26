using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class OrderIngredient
{
    public int OrderIngredientId { get; set; }

    public int? IngredientId { get; set; }

    public int? OrderId { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual Order? Order { get; set; }
}
