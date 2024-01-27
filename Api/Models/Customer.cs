using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public int? CustomerStatusId { get; set; }

    public virtual CustomerStatus? CustomerStatus { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
