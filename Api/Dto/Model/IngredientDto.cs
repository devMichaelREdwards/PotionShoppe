using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class IngredientDto : IDto<Ingredient>
{
    public int? IngredientId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public int? Cost { get; set; }

    public int? CurrentStock { get; set; }

    public string? Image { get; set; }

    public int? EffectId { get; set; }
    public int? IngredientCategoryId { get; set; }

    public EffectDto? Effect { get; set; }
    public IngredientCategoryDto? IngredientCategory { get; set; }

    public bool Equals(Ingredient? other)
    {
        return other != null
            && other.IngredientId == IngredientId
            && other.Product.Name == Name
            && other.Product.Description == Description
            && other.Product.Price == Price
            && other.Product.Cost == Cost
            && other.Product.CurrentStock == CurrentStock
            && other.Product.Image == Image
            && other.EffectId == EffectId
            && other.IngredientCategoryId == IngredientCategoryId;
    }

    public void Update(Ingredient dest)
    {
        dest.IngredientId = IngredientId ?? dest.IngredientId;
        dest.Product.Name = Name ?? dest.Product.Name;
        dest.Product.Description = Description ?? dest.Product.Description;
        dest.Product.Price = Price ?? dest.Product.Price;
        dest.Product.Cost = Cost ?? dest.Product.Cost;
        dest.Product.CurrentStock = CurrentStock ?? dest.Product.CurrentStock;
        dest.Product.Image = Image ?? dest.Product.Image;
        dest.EffectId = EffectId ?? dest.EffectId;
        dest.IngredientCategoryId = IngredientCategoryId ?? dest.IngredientCategoryId;
    }
}
