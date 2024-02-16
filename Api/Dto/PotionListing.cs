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

    public List<PotionEffectListing>? PotionEffects { get; set; } = [];

    public static List<PotionEffectListing> BuildEffectsList(Potion potion) {
        List<PotionEffectListing> effects = [];
        foreach(PotionEffect effect in potion.PotionEffects) {
            effects.Add(new PotionEffectListing() {
                Title = effect?.Effect?.Name!,
                Color = effect?.Effect?.Color!
            });
        }

        return effects;
    }
}
