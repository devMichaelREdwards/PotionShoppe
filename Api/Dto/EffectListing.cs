namespace Api.Models;

public partial class EffectListing
{
    public int? EffectId { get; set; }
    public string? Name { get; set; }
    public int? Value { get; set; }
    public int? Duration { get; set; }
    public string? Description { get; set; }
    public EffectDisplayListing? Color { get; set; }

    public static EffectDisplayListing BuildEffectColor(Effect effect)
    {
        return new EffectDisplayListing()
        {
            Title = effect.Color,
            Color = effect.Color
        };
    }
}
