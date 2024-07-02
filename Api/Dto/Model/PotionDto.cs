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
            && other.Name == Name
            && other.Description == Description
            && other.Products.First().Price == Price
            && other.Products.First().Cost == Cost
            && other.Products.First().CurrentStock == CurrentStock
            && other.Image == Image
            && other.EmployeeId == EmployeeId;
    }

    public void Update(Potion dest)
    {
        dest.Name = Name ?? dest.Name;
        dest.Description = Description ?? dest.Description;
        dest.Products.First().Price = Price ?? dest.Products.First().Price;
        dest.Products.First().Cost = Cost ?? dest.Products.First().Cost;
        dest.Products.First().CurrentStock = CurrentStock ?? dest.Products.First().CurrentStock;
        dest.Image = Image ?? dest.Image;
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
