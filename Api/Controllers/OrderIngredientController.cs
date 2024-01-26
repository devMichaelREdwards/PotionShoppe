using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderIngredientController : ControllerBase
{
    private readonly IRepository<OrderIngredient> potionIngredients;
    private readonly IMapper mapper;

    public OrderIngredientController(
        IRepository<OrderIngredient> _potionIngredients,
        IMapper _mapper
    )
    {
        potionIngredients = _potionIngredients;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetOrderIngredients()
    {
        var result = potionIngredients.Get();
        return Ok(mapper.Map<List<OrderIngredientDto>>(result));
    }

    [HttpPost]
    public IActionResult PostOrderIngredient(OrderIngredientDto potionIngredient)
    {
        potionIngredients.Insert(mapper.Map<OrderIngredient>(potionIngredient));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutOrderIngredient(OrderIngredientDto potionIngredient)
    {
        if (potionIngredient.OrderIngredientId == null)
            return Ok();

        OrderIngredient existing = potionIngredients.GetById(
            (int)potionIngredient.OrderIngredientId
        );
        potionIngredient.Update(existing);
        potionIngredients.Update(existing);

        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteOrderIngredient(OrderIngredientDto potionIngredient)
    {
        if (potionIngredient.OrderIngredientId != null)
            potionIngredients.Delete((int)potionIngredient.OrderIngredientId);
        return Ok();
    }
}
