using Api.Classes;
using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IngredientCategoryController : ControllerBase
{
    private readonly ICategoryRepository<IngredientCategory> _ingredientCategories;
    private readonly IMapper _mapper;

    public IngredientCategoryController(ICategoryRepository<IngredientCategory> ingredientCategories, IMapper mapper)
    {
        _ingredientCategories = ingredientCategories;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetIngredientCategories()
    {
        var result = _ingredientCategories.Get();
        return Ok(_mapper.Map<List<IngredientCategoryDto>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PostIngredientCategory(IngredientCategoryDto ingredientCategory)
    {
        _ingredientCategories.Insert(_mapper.Map<IngredientCategory>(ingredientCategory));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PutIngredientCategory(IngredientCategoryDto ingredientCategory)
    {
        ErrorCollection errors = SetErrors(ingredientCategory, true);
        if (ingredientCategory.IngredientCategoryId == null)
            return Ok();
        IngredientCategory existing = _ingredientCategories.GetById((int)ingredientCategory.IngredientCategoryId);
        if (existing is null)
        {
            errors.Add("exist", "This ingredient was not found. Please refresh the listing.");
        }
        ingredientCategory.Update(existing);
        _ingredientCategories.Update(existing);

        if (errors.Error) return Ok(errors);
        return Ok(true);
    }

    [HttpDelete]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult DeleteIngredientCategory(IngredientCategoryDto ingredientCategory)
    {
        if (ingredientCategory.IngredientCategoryId != null)
            _ingredientCategories.Delete((int)ingredientCategory.IngredientCategoryId);
        return Ok();
    }

    [HttpPost("remove")]
    [Authorize(Roles = "Employee")]
    public IActionResult RemoveIngredients(IngredientCategoryDto ingredientCategory)
    {
        ErrorCollection errors = new();
        if (ingredientCategory.IngredientCategoryId is null)
        {
            errors.Add("error", "No category Id found.");
            return Ok();
        }

        int id = (int)ingredientCategory.IngredientCategoryId;
        bool categoryIsEmpty = _ingredientCategories.IsEmpty(id);
        if (!categoryIsEmpty)
        {
            errors.Add("error", "Category is not empty");
            return Ok(errors);
        }

        _ingredientCategories.Delete(id);
        bool success = true;
        return Ok(success);
    }

    private ErrorCollection SetErrors(IngredientCategoryDto ingredientCategory, bool withId = false)
    {
        ErrorCollection errors = new();
        if (withId && ingredientCategory.IngredientCategoryId == null)
        {
            errors.Add("id", "Invalid Ingredient ID sent with request.");
        }
        if (ingredientCategory.Title.Length < 1)
        {
            errors.Add("name", "Name must be at least 1 character.");
        }

        return errors;
    }
}
