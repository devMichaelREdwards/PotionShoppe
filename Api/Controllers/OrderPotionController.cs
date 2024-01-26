using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderPotionController : ControllerBase
{
    private readonly IRepository<OrderPotion> orderPotions;
    private readonly IMapper mapper;

    public OrderPotionController(
        IRepository<OrderPotion> _orderPotions,
        IMapper _mapper
    )
    {
        orderPotions = _orderPotions;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetOrderPotions()
    {
        var result = orderPotions.Get();
        return Ok(mapper.Map<List<OrderPotionDto>>(result));
    }

    [HttpPost]
    public IActionResult PostOrderPotion(OrderPotionDto orderPotion)
    {
        orderPotions.Insert(mapper.Map<OrderPotion>(orderPotion));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutOrderPotion(OrderPotionDto orderPotion)
    {
        if (orderPotion.OrderPotionId == null)
            return Ok();

        OrderPotion existing = orderPotions.GetById(
            (int)orderPotion.OrderPotionId
        );
        orderPotion.Update(existing);
        orderPotions.Update(existing);

        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteOrderPotion(OrderPotionDto orderPotion)
    {
        if (orderPotion.OrderPotionId != null)
            orderPotions.Delete((int)orderPotion.OrderPotionId);
        return Ok();
    }
}
