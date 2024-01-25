namespace Api.Models;

public partial class CustomerDto
{
    public int? CustomerId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }
    public string? CustomerStatus { get; set; } = String.Empty;
    public int? CustomerStatusId { get; set; }
}
