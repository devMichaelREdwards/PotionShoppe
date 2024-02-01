using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderController : ControllerBase
{
    private readonly IRepository<Order> orders;
    private readonly IMapper mapper;

    public OrderController(IRepository<Order> _orders, IMapper _mapper)
    {
        orders = _orders;
        mapper = _mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Customer,Employee,Owner")]
    public IActionResult GetOrders()
    {
        var result = orders.Get();
        return Ok(mapper.Map<List<OrderDto>>(result));
    }

    [HttpPost]
    public IActionResult PostOrder(OrderDto order)
    {
        order.DatePlaced = DateOnly.FromDateTime(DateTime.Today);
        orders.Insert(mapper.Map<Order>(order));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutOrder(OrderDto order)
    {
        if (order.OrderId == null)
            return Ok();

        Order existing = orders.GetById((int)order.OrderId);
        order.Update(existing);
        orders.Update(existing);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteOrder(OrderDto order)
    {
        if (order.OrderId != null)
            orders.Delete((int)order.OrderId);
        return Ok();
    }
}
