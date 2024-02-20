namespace Api.Models;

public partial class CustomerDto : IDto<Customer>, IUpdate<Customer>
{
    public int? CustomerId { get; set; }

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? CustomerStatusId { get; set; }
    public CustomerStatusDto? CustomerStatus { get; set; }

    public bool Equals(Customer? other)
    {
        return other != null
            && other.CustomerId == CustomerId
            && other.FirstName == FirstName
            && other.LastName == LastName
            && other?.CustomerStatusId == CustomerStatusId;
    }

    public void Update(Customer dest)
    {
        dest.FirstName = FirstName ?? dest.FirstName;
        dest.LastName = LastName ?? dest.LastName;
        dest.CustomerStatusId = CustomerStatusId ?? dest.CustomerStatusId;
    }
}
