using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class OrderStatus
{
    public int OrderStatusId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
