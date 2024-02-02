using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class OrderPotion
{
    public int OrderPotionId { get; set; }

    public int? PotionId { get; set; }

    public int? OrderId { get; set; }

    public int? Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Potion? Potion { get; set; }
}
