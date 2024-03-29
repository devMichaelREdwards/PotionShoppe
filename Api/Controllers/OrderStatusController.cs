using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderStatusController : ControllerBase
{
    private readonly IRepository<OrderStatus> orderStatuses;
    private readonly IMapper mapper;

    public OrderStatusController(IRepository<OrderStatus> _orderStatuses, IMapper _mapper)
    {
        orderStatuses = _orderStatuses;
        mapper = _mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult GetOrderStatuses()
    {
        var result = orderStatuses.Get();
        return Ok(mapper.Map<List<OrderStatusDto>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PostOrderStatus(OrderStatusDto status)
    {
        orderStatuses.Insert(mapper.Map<OrderStatus>(status));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PutOrderStatus(OrderStatusDto status)
    {
        orderStatuses.Update(mapper.Map<OrderStatus>(status));
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult DeleteOrderStatus(OrderStatusDto status)
    {
        if (status.OrderStatusId != null)
            orderStatuses.Delete((int)status.OrderStatusId);
        return Ok();
    }
}
