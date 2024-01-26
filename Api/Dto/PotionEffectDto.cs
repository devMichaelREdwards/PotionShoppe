using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Api.Models;

public partial class PotionEffectDto : IDto<PotionEffect>
{
    public int? PotionEffectId { get; set; }

    public int? PotionId { get; set; }

    public int? EffectId { get; set; }

    public EffectDto? Effect { get; set; }

    public bool Equals(PotionEffect? other)
    {
        throw new NotImplementedException();
    }

    public void Update(PotionEffect dest)
    {
        throw new NotImplementedException();
    }

    public string EffectDescription()
    {
        return Effect.BuildDescription();
    }
}
