namespace Api.Models;

public partial class CustomerStatusDto : IDto<CustomerStatusDto>
{
    public int? CustomerStatusId { get; set; }

    public string? Title { get; set; }

    public bool Equals(CustomerStatusDto? other)
    {
        return other?.CustomerStatusId == CustomerStatusId && other?.Title == Title;
    }
}
