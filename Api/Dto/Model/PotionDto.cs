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

    public ICollection<PotionEffectDto>? PotionEffects { get; set; } = new List<PotionEffectDto>();

    public bool Equals(Potion? other)
    {
        return other != null
            && other.PotionId == PotionId
            && other.Name == Name
            && other.Description == Description
            && other.Price == Price
            && other.Cost == Cost
            && other.CurrentStock == CurrentStock
            && other.Image == Image
            && other.EmployeeId == EmployeeId;
    }

    public void Update(Potion dest)
    {
        dest.Name = Name ?? dest.Name;
        dest.Description = Description ?? dest.Description;
        dest.Price = Price ?? dest.Price;
        dest.Cost = Cost ?? dest.Cost;
        dest.CurrentStock = CurrentStock ?? dest.CurrentStock;
        dest.Image = Image ?? dest.Image;
        dest.EmployeeId = EmployeeId ?? dest.EmployeeId;
    }
}
