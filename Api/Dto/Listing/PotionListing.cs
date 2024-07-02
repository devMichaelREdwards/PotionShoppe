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
    public bool? Active { get; set; }

    public List<EffectDisplayListing>? PotionEffects { get; set; } = [];

    public static List<EffectDisplayListing> BuildEffectsList(Potion potion)
    {
        List<EffectDisplayListing> effects = [];
        foreach (PotionEffect effect in potion.PotionEffects)
        {
            effects.Add(new EffectDisplayListing()
            {
                EffectId = effect.EffectId,
                Title = effect?.Effect?.Name!,
                Description = EffectDto.BuildDescription(effect?.Effect!),
                Color = effect?.Effect?.Color!
            });
        }

        return effects;
    }
}
