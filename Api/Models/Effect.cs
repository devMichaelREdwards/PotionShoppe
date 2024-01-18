using System.Text.Json.Serialization;

namespace Api.Models;

public partial class Effect
{
    public int EffectId { get; set; }

    public int? Value { get; set; }

    public int? Duration { get; set; }

    public string? Description { get; set; }

    [JsonIgnore]
    public virtual ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    [JsonIgnore]
    public virtual ICollection<PotionEffect> PotionEffects { get; set; } = new List<PotionEffect>();
}
