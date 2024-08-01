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
        if (ingredientCategory.IngredientCategoryId == null)
            return Ok();
        IngredientCategory existing = _ingredientCategories.GetById((int)ingredientCategory.IngredientCategoryId);
        ingredientCategory.Update(existing);
        _ingredientCategories.Update(existing);
        return Ok();
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

        if (ingredientCategory.IngredientCategoryId is null)
        {
            return BadRequest();
        }

        int id = (int)ingredientCategory.IngredientCategoryId;
        bool categoryIsEmpty = _ingredientCategories.IsEmpty(id);
        if (!categoryIsEmpty)
        {
            return BadRequest();
        }

        _ingredientCategories.Delete(id);
        bool success = true;
        return Ok(success);
    }
}
