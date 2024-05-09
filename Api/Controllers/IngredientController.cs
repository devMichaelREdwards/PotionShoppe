using Api.Classes;
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
    private readonly IListingRepository<Ingredient> _ingredients;
    private readonly IListingRepository<Effect> _effects;
    private readonly IMapper _mapper;

    public IngredientController(IListingRepository<Ingredient> ingredients, IListingRepository<Effect> effects, IMapper mapper)
    {
        _ingredients = ingredients;
        _effects = effects;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetIngredients()
    {
        var result = _ingredients.Get();
        return Ok(_mapper.Map<List<IngredientDto>>(result));
    }

    [HttpGet("{id}")]
    public IActionResult GetIngredientListing(int? id)
    {
        if (id == null) return BadRequest("Invalid request");
        var result = _ingredients.GetById((int)id);
        if (result == null) return BadRequest("No resource found");
        return Ok(_mapper.Map<IngredientDto>(result));
    }

    [HttpGet("listing")]
    public IActionResult GetIngredientListing()
    {
        IngredientFilter? filter = IngredientFilter.BuildFilter(Request.Query);
        Pagination? page = Pagination.BuildFilter(Request.Query);
        SortOrder? sortOrder = SortOrder.BuildFilter(Request.Query);
        var result = _ingredients.GetListing(filter, page, sortOrder);
        return Ok(_mapper.Map<List<IngredientListing>>(result));
    }

    [HttpGet("filters")]
    public IActionResult GetFilterInfo()
    {
        IngredientFilter filterLimits = (IngredientFilter)_ingredients.GetFilterData();
        return Ok(filterLimits);
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public IActionResult PostIngredient(IngredientDto ingredient)
    {
        ErrorCollection errors = SetErrors(ingredient);
        if (errors.Error) return BadRequest(errors);
        _ingredients.Insert(_mapper.Map<Ingredient>(ingredient));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee")]
    public IActionResult PutIngredient(IngredientDto ingredient)
    {
        ErrorCollection errors = SetErrors(ingredient, true);
        Ingredient existing = _ingredients.GetById((int)ingredient.IngredientId);
        if (existing is null)
        {
            errors.Add("exist", "This ingredient was not found. Please refresh the listing.");
        }
        ingredient.Update(existing!);
        _ingredients.Update(existing!);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Employee")]
    public IActionResult DeleteIngredient(IngredientDto ingredient)
    {
        if (ingredient.IngredientId != null)
            _ingredients.Delete((int)ingredient.IngredientId);
        return Ok();
    }

    [HttpPost("remove")]
    [Authorize(Roles = "Employee")]
    public IActionResult RemoveIngredients(int[] ids)
    {
        foreach (int id in ids)
        {
            _ingredients.Delete(id);
        }
        return Ok();
    }

    private ErrorCollection SetErrors(IngredientDto ingredient, bool withId = false)
    {
        ErrorCollection errors = new();
        if (withId && ingredient.IngredientId == null)
        {
            errors.Add("id", "Invalid Ingredient ID sent with request.");
        }
        if (ingredient.Name.Length < 3)
        {
            errors.Add("name", "Name must be 3 characters.");
        }

        if (ingredient.IngredientCategoryId == null)
        {
            errors.Add("id", "Invalid Category ID sent with request.");
        }

        if (ingredient.Price < 0)
        {
            errors.Add("price", "Price must be positive.");
        }

        if (ingredient.Cost < 0)
        {
            errors.Add("cost", "Cost must be positive.");
        }

        if (ingredient.CurrentStock < 0)
        {
            errors.Add("instock", "Stock must be positive.");
        }

        if (_effects.GetById(ingredient.EffectId ?? -1) == null)
        {
            errors.Add("effect", "Invalid Effect ID sent with request.");
        }

        return errors;
    }
}
