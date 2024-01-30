using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class CustomerAccount
{
    public int CustomerAccountId { get; set; }

    public string? UserId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
}
