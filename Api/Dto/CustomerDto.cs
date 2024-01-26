namespace Api.Models;

public partial class CustomerDto : IDto<Customer>, IUpdate<Customer>
{
    public int? CustomerId { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public string? Name { get; set; }
    public int? CustomerStatusId { get; set; }
    public CustomerStatusDto? CustomerStatus { get; set; }

    public bool Equals(Customer? other)
    {
        return other != null
            && other.CustomerId == CustomerId
            && other?.Username == Username
            && other?.Password == Password
            && other?.Name == Name
            && other?.CustomerStatusId == CustomerStatusId;
    }

    public void Update(Customer dest)
    {
        dest.Password = Password ?? dest.Password;
        dest.Name = Name ?? dest.Name;
        dest.CustomerStatusId = CustomerStatusId ?? dest.CustomerStatusId;
    }
}
