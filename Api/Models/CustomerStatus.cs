using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class CustomerStatus
{
    public int CustomerStatusId { get; set; }

    public string? Title { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = new List<Customer>();
}
