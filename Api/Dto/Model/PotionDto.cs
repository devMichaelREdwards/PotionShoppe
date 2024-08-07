using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class PotionDto : IDto<Potion>
{
    public int? PotionId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public int? Cost { get; set; }

    public int? CurrentStock { get; set; }

    public string? Image { get; set; }

    public int? EmployeeId { get; set; }

    public string? Employee { get; set; }
    public bool? Active { get; set; }

    public ICollection<PotionEffectDto>? PotionEffects { get; set; } = new List<PotionEffectDto>();

    public bool Equals(Potion? other)
    {
        return other != null
            && other.PotionId == PotionId
            && other.Product.Name == Name
            && other.Product.Description == Description
            && other.Product.Price == Price
            && other.Product.Cost == Cost
            && other.Product.CurrentStock == CurrentStock
            && other.Product.Image == Image
            && other.EmployeeId == EmployeeId;
    }

    public void Update(Potion dest)
    {
        dest.Product.Name = Name ?? dest.Product.Name;
        dest.Product.Description = Description ?? dest.Product.Description;
        dest.Product.Price = Price ?? dest.Product.Price;
        dest.Product.Cost = Cost ?? dest.Product.Cost;
        dest.Product.CurrentStock = CurrentStock ?? dest.Product.CurrentStock;
        dest.Product.Image = Image ?? dest.Product.Image;
        dest.EmployeeId = EmployeeId ?? dest.EmployeeId;
        dest.PotionEffects = UpdatePotionEffects(PotionEffects) ?? dest.PotionEffects;
    }

    private ICollection<PotionEffect>? UpdatePotionEffects(ICollection<PotionEffectDto>? effects)
    {
        if (effects is null)
            return null;
        ICollection<PotionEffect> newEffects = new List<PotionEffect>();
        foreach (PotionEffectDto effectDto in effects)
        {
            newEffects.Add(
                new PotionEffect() { PotionId = effectDto.PotionId, EffectId = effectDto.EffectId, }
            );
        }
        return newEffects;
    }
}
