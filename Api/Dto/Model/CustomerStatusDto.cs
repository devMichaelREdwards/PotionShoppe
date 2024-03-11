namespace Api.Models;

public partial class CustomerStatusDto : IDto<CustomerStatus>
{
    public int? CustomerStatusId { get; set; }

    public string? Title { get; set; }

    public bool Equals(CustomerStatus? other)
    {
        return other?.CustomerStatusId == CustomerStatusId && other?.Title == Title;
    }

    public void Update(CustomerStatus dest)
    {
        dest.Title = Title;
    }
}
