using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string? OrderNumber { get; set; }

    public int? CustomerId { get; set; }

    public int? OrderStatusId { get; set; }

    public int? Total { get; set; }

    public DateOnly? DatePlaced { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderIngredient> OrderIngredients { get; set; } = new List<OrderIngredient>();

    public virtual ICollection<OrderPotion> OrderPotions { get; set; } = new List<OrderPotion>();

    public virtual OrderStatus? OrderStatus { get; set; }

    public virtual ICollection<Receipt> Receipts { get; set; } = new List<Receipt>();
}
