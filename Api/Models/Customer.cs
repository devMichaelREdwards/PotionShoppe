using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }

    public int? CustomerStatusId { get; set; }

    public virtual CustomerStatus? CustomerStatus { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
