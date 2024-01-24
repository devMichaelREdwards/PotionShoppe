namespace Api.Models;

public partial class EffectDto : IDto<EffectDto>
{
    public int? EffectId { get; set; }

    public string? Value { get; set; }
    public int? Duration { get; set; }

    public string? Description { get; set; }

    public bool Equals(EffectDto? other)
    {
        return other?.EffectId == EffectId
            && other?.Value == Value
            && other?.Duration == Duration
            && other?.Description == Description;
    }
}
