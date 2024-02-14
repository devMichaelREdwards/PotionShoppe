using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class PotionListing
{
    public int? PotionId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public int? Cost { get; set; }

    public int? CurrentStock { get; set; }

    public string? Image { get; set; }

    public List<string>? PotionEffects { get; set; } = [];

    public static List<string> BuildEffectsList(Potion potion) {
        List<string> effects = [];
        foreach(PotionEffect effect in potion.PotionEffects) {
            effects.Add(effect?.Effect?.Name!);
        }

        return effects;
    }
}
