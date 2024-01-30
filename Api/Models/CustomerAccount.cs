namespace Api.Models;

public partial class CustomerAccount
{
    public required string CustomerAccountId { get; set; }

    public int? CustomerId { get; set; }

    public virtual Customer? Customer { get; set; }
}
