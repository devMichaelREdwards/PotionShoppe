using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Potion
{
    public int PotionId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Image { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<OrderPotion> OrderPotions { get; set; } = new List<OrderPotion>();

    public virtual ICollection<PotionEffect> PotionEffects { get; set; } = new List<PotionEffect>();

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
