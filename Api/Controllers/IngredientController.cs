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
    private readonly IListingRepository<Ingredient> ingredients;
    private readonly IMapper mapper;

    public IngredientController(IListingRepository<Ingredient> _ingredients, IMapper _mapper)
    {
        ingredients = _ingredients;
        mapper = _mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetIngredients()
    {
        var result = ingredients.Get();
        return Ok(mapper.Map<List<IngredientDto>>(result));
    }

    [HttpGet("listing")]
    public IActionResult GetIngredientListing()
    {
        IngredientFilter? filter = IngredientFilter.BuildFilter(Request.Query);
        Pagination? page = Pagination.BuildFilter(Request.Query);
        var result = ingredients.GetListing(filter, page);
        return Ok(mapper.Map<List<IngredientListing>>(result));
    }

    [HttpGet("filters")]
    public IActionResult GetFilterInfo()
    {
        IngredientFilter filterLimits = (IngredientFilter)ingredients.GetFilterData();
        return Ok(filterLimits);
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public IActionResult PostIngredient(IngredientDto ingredient)
    {
        ingredients.Insert(mapper.Map<Ingredient>(ingredient));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee")]
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
    [Authorize(Roles = "Employee")]
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
