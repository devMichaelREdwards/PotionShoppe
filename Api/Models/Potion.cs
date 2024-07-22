using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Potion
{
    public int PotionId { get; set; }

    public int? EmployeeId { get; set; }

    public int? ProductId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<PotionEffect> PotionEffects { get; set; } = new List<PotionEffect>();

    public virtual Product? Product { get; set; }
}
