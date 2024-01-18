namespace Api.Models;

public partial class PotionEffect
{
    public int PotionEffectId { get; set; }

    public int? PotionId { get; set; }

    public int? EffectId { get; set; }

    public virtual Effect? Effect { get; set; }

    public virtual Potion? Potion { get; set; }
}
