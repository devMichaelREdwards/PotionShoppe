using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientController : ControllerBase
{
    private readonly IRepository<Ingredient> ingredients;
    private readonly IMapper mapper;

    public IngredientController(IRepository<Ingredient> _ingredients, IMapper _mapper)
    {
        ingredients = _ingredients;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetIngredients()
    {
        var result = ingredients.Get();
        return Ok(mapper.Map<List<IngredientDto>>(result));
    }

    [HttpPost]
    public IActionResult PostIngredient(IngredientDto customer)
    {
        ingredients.Insert(mapper.Map<Ingredient>(customer));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutIngredient(IngredientDto customer)
    {
        if (customer.IngredientId == null)
            return Ok();

        Ingredient existing = ingredients.GetById((int)customer.IngredientId);
        customer.Update(existing);
        ingredients.Update(existing);

        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteIngredient(IngredientDto customer)
    {
        if (customer.IngredientId != null)
            ingredients.Delete((int)customer.IngredientId);
        return Ok();
    }
}
