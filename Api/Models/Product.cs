using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public int? IngredientId { get; set; }

    public int? PotionId { get; set; }

    public int? Price { get; set; }

    public int? Cost { get; set; }

    public int? CurrentStock { get; set; }

    public DateOnly? DateAdded { get; set; }

    public bool? Active { get; set; }

    public virtual Ingredient? Ingredient { get; set; }

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual Potion? Potion { get; set; }
}
