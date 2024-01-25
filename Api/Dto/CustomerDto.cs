namespace Api.Models;

public partial class CustomerDto : IDto<Customer>, IUpdate<Customer>
{
    public int? CustomerId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }
    public string? CustomerStatus { get; set; } = String.Empty;
    public int? CustomerStatusId { get; set; }

    public bool Equals(Customer? other)
    {
        throw new NotImplementedException();
    }

    public void Update(Customer dest)
    {
        dest.CustomerId = CustomerId ?? dest.CustomerId;
        dest.Username = dest.Username;
        dest.Password = Password ?? dest.Password;
        dest.Name = Name ?? dest.Name;
        dest.CustomerStatusId = CustomerStatusId ?? dest.CustomerStatusId;
    }
}
