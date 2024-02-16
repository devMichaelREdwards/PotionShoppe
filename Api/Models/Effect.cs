using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Effect
{
    public int EffectId { get; set; }

    public string? Name { get; set; }

    public int? Value { get; set; }

    public int? Duration { get; set; }

    public string? Description { get; set; }

    public string? Color { get; set; }

    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public virtual ICollection<PotionEffect> PotionEffects { get; set; } = new List<PotionEffect>();
}
