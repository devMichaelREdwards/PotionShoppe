using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrderIngredientController : ControllerBase
{
    private readonly IRepository<OrderIngredient> orderIngredients;
    private readonly IMapper mapper;

    public OrderIngredientController(
        IRepository<OrderIngredient> _orderIngredients,
        IMapper _mapper
    )
    {
        orderIngredients = _orderIngredients;
        mapper = _mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Customer,Employee,Owner")]
    public IActionResult GetOrderIngredients()
    {
        var result = orderIngredients.Get();
        return Ok(mapper.Map<List<OrderIngredientDto>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Customer,Employee,Owner")]
    public IActionResult PostOrderIngredient(OrderIngredientDto orderIngredient)
    {
        orderIngredients.Insert(mapper.Map<OrderIngredient>(orderIngredient));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Customer,Employee,Owner")]
    public IActionResult PutOrderIngredient(OrderIngredientDto orderIngredient)
    {
        if (orderIngredient.OrderIngredientId == null)
            return Ok();

        OrderIngredient existing = orderIngredients.GetById(
            (int)orderIngredient.OrderIngredientId
        );
        orderIngredient.Update(existing);
        orderIngredients.Update(existing);

        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Customer,Employee,Owner")]
    public IActionResult DeleteOrderIngredient(OrderIngredientDto orderIngredient)
    {
        if (orderIngredient.OrderIngredientId != null)
            orderIngredients.Delete((int)orderIngredient.OrderIngredientId);
        return Ok();
    }
}
