using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ScriptController : ControllerBase
{
    private readonly IListingRepository<Potion> _potions;
    private readonly IListingRepository<Ingredient> _ingredients;
    private readonly IRepository<Product> _products;
    private readonly IMapper _mapper;

    public ScriptController(
        IListingRepository<Potion> potions,
        IListingRepository<Ingredient> ingredients,
        IRepository<Product> products,
        IMapper mapper
    )
    {
        _potions = potions;
        _ingredients = ingredients;
        _products = products;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetScripts()
    {
        return Ok();
    }

    [HttpGet("enable-all-products")]
    public IActionResult EnableProducts()
    {
        var getProducts = _products.Get();

        foreach (Product p in getProducts)
        {
            p.Active = true;
            _products.Update(p);
        }
        return Ok();
    }

    [HttpGet("disable-all-products")]
    public IActionResult DisableProducts()
    {
        var getProducts = _products.Get();

        foreach (Product p in getProducts)
        {
            p.Active = true;
            _products.Update(p);
        }
        return Ok();
    }
}
