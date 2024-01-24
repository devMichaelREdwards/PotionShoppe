using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderStatusController : ControllerBase
{
    private readonly IRepository<OrderStatus> employeeStatuses;
    private readonly IMapper mapper;

    public OrderStatusController(IRepository<OrderStatus> _employeeStatuses, IMapper _mapper)
    {
        employeeStatuses = _employeeStatuses;
        mapper = _mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetOrderStatuses()
    {
        var result = employeeStatuses.Get();
        return Ok(mapper.Map<List<OrderStatusDto>>(result));
    }

    [HttpPost]
    public async Task<IActionResult> PostOrderStatus(OrderStatusDto status)
    {
        employeeStatuses.Insert(mapper.Map<OrderStatus>(status));
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutOrderStatus(OrderStatusDto status)
    {
        employeeStatuses.Update(mapper.Map<OrderStatus>(status));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteOrderStatus(OrderStatusDto status)
    {
        if (status.OrderStatusId != null)
            employeeStatuses.Delete((int)status.OrderStatusId);
        return Ok();
    }
}
