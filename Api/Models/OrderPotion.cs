namespace Api.Models;

public partial class OrderPotion
{
    public int OrderPotionId { get; set; }

    public int? PotionId { get; set; }

    public int? OrderId { get; set; }

    public virtual Potion? Order { get; set; }

    public virtual Potion? Potion { get; set; }
}
