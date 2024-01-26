namespace Api.Models;

public partial class OrderStatusDto : IDto<OrderStatus>
{
    public int? OrderStatusId { get; set; }

    public string? Title { get; set; }

    public bool Equals(OrderStatus? other)
    {
        return other?.OrderStatusId == OrderStatusId && other?.Title == Title;
    }

    public void Update(OrderStatus dest)
    {
        dest.Title = Title;
    }
}
