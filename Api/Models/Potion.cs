namespace Api.Models;

public partial class Potion
{
    public int PotionId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public int? Price { get; set; }

    public int? Cost { get; set; }

    public int? CurrentStock { get; set; }

    public string? Image { get; set; }

    public int? EmployeeId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual ICollection<OrderPotion> OrderPotionOrders { get; set; } =
        new List<OrderPotion>();

    public virtual ICollection<OrderPotion> OrderPotionPotions { get; set; } =
        new List<OrderPotion>();

    public virtual ICollection<PotionEffect> PotionEffects { get; set; } = new List<PotionEffect>();
}
