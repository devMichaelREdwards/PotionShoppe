namespace Api.Models;

public partial class PotionEffectDto : IDto<PotionEffect>
{
    public int? PotionEffectId { get; set; }

    public int? PotionId { get; set; }

    public int? EffectId { get; set; }
    public string? Potion { get; set; }

    public string? Effect { get; set; }

    public bool Equals(PotionEffect? other)
    {
        return other != null
            && other.PotionEffectId == PotionEffectId
            && other.PotionId == PotionId
            && other.EffectId == EffectId;
    }

    public void Update(PotionEffect dest)
    {
        dest.EffectId = EffectId ?? dest.EffectId;
    }
}
