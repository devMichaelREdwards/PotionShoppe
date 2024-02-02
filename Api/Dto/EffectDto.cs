namespace Api.Models;

public partial class EffectDto : IDto<Effect>
{
    public int? EffectId { get; set; }
    public string? Name { get; set; }
    public int? Value { get; set; }
    public int? Duration { get; set; }

    public string? Description { get; set; }

    public bool Equals(Effect? other)
    {
        return other?.EffectId == EffectId
            && other?.Name == Name
            && other?.Value == Value
            && other?.Duration == Duration
            && other?.Description == Description;
    }

    public void Update(Effect dest)
    {
        dest.Name = Name ?? dest.Name;
        dest.Value = Value ?? dest.Value;
        dest.Duration = Duration ?? dest.Duration;
        dest.Description = Description ?? dest.Description;
    }

    public string BuildDescription()
    {
        return string.Format(Description, Value, Duration);
    }

    public static string BuildDescription(Effect effect)
    {
        return string.Format(effect.Description, effect.Value, effect.Duration);
    }
}
