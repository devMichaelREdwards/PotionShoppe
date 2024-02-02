using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Api.Models;

public partial class OrderPotionDto : IDto<OrderPotion>
{
    public int? OrderPotionId { get; set; }

    public int? OrderId { get; set; }

    public int? PotionId { get; set; }
    public int? Quantity { get; set; }

    public PotionDto? Potion { get; set; }

    public bool Equals(OrderPotion? other)
    {
        return other != null
            && other.OrderPotionId == OrderPotionId
            && other.OrderId == OrderId
            && other.PotionId == PotionId
            && other.Quantity == Quantity;
    }

    public void Update(OrderPotion dest)
    {
        dest.PotionId = PotionId ?? dest.PotionId;
        dest.Quantity = Quantity ?? dest.Quantity;
    }
}
