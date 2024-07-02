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
            && other.Name == Name
            && other.Description == Description
            && other.Products.First().Price == Price
            && other.Products.First().Cost == Cost
            && other.Products.First().CurrentStock == CurrentStock
            && other.Image == Image
            && other.EffectId == EffectId
            && other.IngredientCategoryId == IngredientCategoryId;
    }

    public void Update(Ingredient dest)
    {
        dest.IngredientId = IngredientId ?? dest.IngredientId;
        dest.Name = Name ?? dest.Name;
        dest.Description = Description ?? dest.Description;
        dest.Products.First().Price = Price ?? dest.Products.First().Price;
        dest.Products.First().Cost = Cost ?? dest.Products.First().Cost;
        dest.Products.First().CurrentStock = CurrentStock ?? dest.Products.First().CurrentStock;
        dest.Image = Image ?? dest.Image;
        dest.EffectId = EffectId ?? dest.EffectId;
        dest.IngredientCategoryId = IngredientCategoryId ?? dest.IngredientCategoryId;
    }
}
