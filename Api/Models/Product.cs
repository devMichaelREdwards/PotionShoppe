using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Product
{
    public int ProductId { get; set; }
    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public int? Price { get; set; }

    public int? Cost { get; set; }

    public int? CurrentStock { get; set; }

    public DateOnly? DateAdded { get; set; }

    public bool? Active { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual ICollection<Potion> Potions { get; set; } = new List<Potion>();
}
