using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PotionController : ControllerBase
{
    private readonly IListingRepository<Potion> _potions;
    private readonly IRepository<EmployeeAccount> _employeeAccounts;
    private readonly IMapper _mapper;

    public PotionController(
        IListingRepository<Potion> potions,
        IRepository<EmployeeAccount> employeeAccounts,
        IMapper mapper
    )
    {
        _potions = potions;
        _employeeAccounts = employeeAccounts;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetPotions()
    {
        var result = _potions.Get();
        return Ok(_mapper.Map<List<PotionDto>>(result));
    }

    [HttpGet("{id}")]
    public IActionResult GetPotionFormData(int? id)
    {
        if (id == null)
            return BadRequest("Invalid request");
        var result = _potions.GetById((int)id);
        if (result == null)
            return BadRequest("No resource found");
        return Ok(_mapper.Map<PotionListing>(result));
    }

    [HttpGet("listing")]
    public IActionResult GetPotionListing()
    {
        PotionFilter? filter = PotionFilter.BuildFilter(Request.Query);
        Pagination? page = Pagination.BuildFilter(Request.Query);
        SortOrder? sortOrder = SortOrder.BuildFilter(Request.Query);
        var result = _potions.GetListing(filter, page, sortOrder);
        return Ok(_mapper.Map<List<PotionListing>>(result));
    }

    [HttpGet("filters")]
    public IActionResult GetFilterInfo()
    {
        PotionFilter filterLimits = (PotionFilter)_potions.GetFilterData();
        return Ok(filterLimits);
    }

    [HttpPost]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PostPotion(PotionDto potion)
    {
        if (potion.EmployeeId == null)
        {
            potion.EmployeeId = (_employeeAccounts as EmployeeAccountRepository)
                .GetByUserName(potion.Employee)
                .EmployeeId;
            potion.Employee = null;
        }
        Potion newPotion = _mapper.Map<Potion>(potion);
        newPotion.Product = new Product()
        {
            Name = potion.Name,
            Description = potion.Description,
            Image = potion.Image,
            Cost = potion.Cost,
            Price = potion.Price,
            CurrentStock = potion.CurrentStock,
            DateAdded = DateOnly.FromDateTime(DateTime.Now),
            Active = true
        };
        _potions.Insert(newPotion);
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PutPotion(PotionDto potion)
    {
        if (potion.PotionId == null)
            return Ok();

        Potion existing = _potions.GetById((int)potion.PotionId);
        potion.Update(existing!);
        _potions.Update(existing!);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult DeletePotion(PotionDto potion)
    {
        if (potion.PotionId != null)
        {
            _potions.Delete((int)potion.PotionId);
        }
        return Ok();
    }

    [HttpPost("remove")]
    [Authorize(Roles = "Employee")]
    public IActionResult RemovePotions(int[] ids)
    {
        foreach (int id in ids)
        {
            _potions.Delete(id);
        }
        return Ok();
    }

    [HttpPost("toggle")]
    [Authorize(Roles = "Employee")]
    public IActionResult TogglePotion(PotionDto toggled)
    {
        if (toggled.PotionId is null)
            return BadRequest();

        Potion? potion = _potions.GetById(toggled.PotionId ?? 0);
        if (potion is null)
            return BadRequest();

        potion.Product.Active = !potion.Product.Active;
        _potions.Update(potion);
        return Ok();
    }
}
