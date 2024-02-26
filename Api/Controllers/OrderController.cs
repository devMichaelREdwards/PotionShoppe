using System.Security.Claims;
using Api.Classes;
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

    public OrderController(IRepository<Order> _orders, IMapper _mapper, IAuthService _authService)
    {
        orders = _orders;
        mapper = _mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetOrders()
    {
        var result = orders.Get();
        return Ok(mapper.Map<List<OrderDto>>(result));
    }

    [HttpGet("listing")]
    [Authorize(Roles = "Employee")]
    public IActionResult GetOrderListing()
    {
        var result = orders.GetListing();
        return Ok(mapper.Map<List<OrderListing>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Customer,Employee,Owner")]
    public IActionResult PostOrder(OrderDto order)
    {
        order.DatePlaced = DateOnly.FromDateTime(DateTime.Today);
        orders.Insert(mapper.Map<Order>(order));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Owner")]
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
    [Authorize(Roles = "Owner")]
    public IActionResult DeleteOrder(OrderDto order)
    {
        if (order.OrderId != null)
            orders.Delete((int)order.OrderId);
        return Ok();
    }
}
