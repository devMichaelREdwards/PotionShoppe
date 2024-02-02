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
    private readonly IRepository<IngredientCategory> ingredientCategory;
    private readonly IMapper mapper;

    public IngredientCategoryController(IRepository<IngredientCategory> _ingredientCategory, IMapper _mapper)
    {
        ingredientCategory = _ingredientCategory;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetIngredientCategories()
    {
        var result = ingredientCategory.Get();
        return Ok(mapper.Map<List<IngredientCategoryDto>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PostIngredientCategory(IngredientCategoryDto customerStatus)
    {
        ingredientCategory.Insert(mapper.Map<IngredientCategory>(customerStatus));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PutIngredientCategory(IngredientCategoryDto customerStatus)
    {
        if (customerStatus.IngredientCategoryId == null)
            return Ok();
        IngredientCategory existing = ingredientCategory.GetById((int)customerStatus.IngredientCategoryId);
        customerStatus.Update(existing);
        ingredientCategory.Update(existing);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult DeleteIngredientCategory(IngredientCategoryDto customerStatus)
    {
        if (customerStatus.IngredientCategoryId != null)
            ingredientCategory.Delete((int)customerStatus.IngredientCategoryId);
        return Ok();
    }
}
