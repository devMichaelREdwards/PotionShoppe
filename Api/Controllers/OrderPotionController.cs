using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderPotionController : ControllerBase
{
    private readonly IRepository<OrderPotion> potionPotions;
    private readonly IMapper mapper;

    public OrderPotionController(
        IRepository<OrderPotion> _potionPotions,
        IMapper _mapper
    )
    {
        potionPotions = _potionPotions;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetOrderPotions()
    {
        var result = potionPotions.Get();
        return Ok(mapper.Map<List<OrderPotionDto>>(result));
    }

    [HttpPost]
    public IActionResult PostOrderPotion(OrderPotionDto potionPotion)
    {
        potionPotions.Insert(mapper.Map<OrderPotion>(potionPotion));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutOrderPotion(OrderPotionDto potionPotion)
    {
        if (potionPotion.OrderPotionId == null)
            return Ok();

        OrderPotion existing = potionPotions.GetById(
            (int)potionPotion.OrderPotionId
        );
        potionPotion.Update(existing);
        potionPotions.Update(existing);

        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteOrderPotion(OrderPotionDto potionPotion)
    {
        if (potionPotion.OrderPotionId != null)
            potionPotions.Delete((int)potionPotion.OrderPotionId);
        return Ok();
    }
}
