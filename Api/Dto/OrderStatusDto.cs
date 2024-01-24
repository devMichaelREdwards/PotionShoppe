namespace Api.Models;

public partial class OrderStatusDto : IDto<OrderStatusDto>
{
    public int? OrderStatusId { get; set; }

    public string? Title { get; set; }

    public bool Equals(OrderStatusDto? other)
    {
        return other?.OrderStatusId == OrderStatusId && other?.Title == Title;
    }
}
