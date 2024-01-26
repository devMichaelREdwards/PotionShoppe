using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.TagHelpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Api.Models;

public partial class OrderIngredientDto : IDto<OrderIngredient>
{
    public int? OrderIngredientId { get; set; }

    public int? OrderId { get; set; }

    public int? IngredientId { get; set; }

    public IngredientDto? Ingredient { get; set; }

    public bool Equals(OrderIngredient? other)
    {
        return other != null
            && other.OrderIngredientId == OrderIngredientId
            && other.OrderId == OrderId
            && other.IngredientId == IngredientId;
    }

    public void Update(OrderIngredient dest)
    {
        dest.IngredientId = IngredientId ?? dest.IngredientId;
    }
}
