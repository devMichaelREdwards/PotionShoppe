namespace Api.Models;

public partial class EffectDto : IDto<Effect>
{
    public int? EffectId { get; set; }

    public int? Value { get; set; }
    public int? Duration { get; set; }

    public string? Description { get; set; }

    public bool Equals(Effect? other)
    {
        return other?.EffectId == EffectId
            && other?.Value == Value
            && other?.Duration == Duration
            && other?.Description == Description;
    }

    public void Update(Effect dest)
    {
        throw new NotImplementedException();
    }
}
