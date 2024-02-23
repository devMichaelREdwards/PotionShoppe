using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet("listing")]
    public IActionResult GetPotionListing()
    {
        var result = ingredients.GetListing();
        return Ok(mapper.Map<List<IngredientListing>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PostIngredient(IngredientDto ingredient)
    {
        ingredients.Insert(mapper.Map<Ingredient>(ingredient));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PutIngredient(IngredientDto ingredient)
    {
        if (ingredient.IngredientId == null)
            return Ok();

        Ingredient existing = ingredients.GetById((int)ingredient.IngredientId);
        ingredient.Update(existing);
        ingredients.Update(existing);

        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult DeleteIngredient(IngredientDto ingredient)
    {
        if (ingredient.IngredientId != null)
            ingredients.Delete((int)ingredient.IngredientId);
        return Ok();
    }

    [HttpPost("remove")]
    [Authorize(Roles = "Employee")]
    public IActionResult RemoveIngredients(int[] ids)
    {
        foreach (int id in ids)
        {
            ingredients.Delete(id);
        }
        return Ok();
    }
}
