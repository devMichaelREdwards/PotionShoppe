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
    private readonly IMapper _mapper;

    public PotionController(IListingRepository<Potion> potions, IMapper mapper)
    {
        _potions = potions;
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
        if (id == null) return BadRequest("Invalid request");
        var result = _potions.GetById((int)id);
        if (result == null) return BadRequest("No resource found");
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
        _potions.Insert(_mapper.Map<Potion>(potion));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PutPotion(PotionDto potion)
    {
        if (potion.PotionId == null)
            return Ok();

        Potion existing = _potions.GetById((int)potion.PotionId);
        potion.Update(existing);
        _potions.Update(existing);
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
}
