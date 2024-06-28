namespace Api.Models;

public partial class CustomerListing
{
    public int? CustomerId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? CustomerStatus { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
}
