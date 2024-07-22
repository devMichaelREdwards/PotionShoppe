using System;
using System.Collections.Generic;

namespace Api.Models;

public partial class OrderDto : IDto<Order>
{
    public int? OrderId { get; set; }

    public string? OrderNumber { get; set; }

    public int? CustomerId { get; set; }

    public int? OrderStatusId { get; set; }

    public int? Total { get; set; }

    public DateOnly? DatePlaced { get; set; }

    public string? Customer { get; set; }

    public OrderStatusDto? OrderStatus { get; set; }

    public bool Equals(Order? other)
    {
        return other != null
            && other.OrderId == OrderId
            && other.OrderNumber == OrderNumber
            && other.CustomerId == CustomerId
            && other.OrderStatusId == OrderStatusId
            && other.Total == Total;
    }

    public void Update(Order dest)
    {
        dest.OrderStatusId = OrderStatusId ?? dest.OrderStatusId;
        dest.Total = Total ?? dest.Total;
    }
}
