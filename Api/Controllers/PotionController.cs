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
    private readonly IListingRepository<Potion> potions;
    private readonly IMapper mapper;

    public PotionController(IListingRepository<Potion> _potions, IMapper _mapper)
    {
        potions = _potions;
        mapper = _mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetPotions()
    {
        var result = potions.Get();
        return Ok(mapper.Map<List<PotionDto>>(result));
    }

    [HttpGet("listing")]
    public IActionResult GetPotionListing()
    {
        PotionFilter? filter = PotionFilter.BuildFilter(Request.Query);
        Pagination? page = Pagination.BuildFilter(Request.Query);
        var result = potions.GetListing(filter, page);
        return Ok(mapper.Map<List<PotionListing>>(result));
    }

    [HttpGet("filters")]
    public IActionResult GetFilterInfo()
    {
        PotionFilter filterLimits = (PotionFilter)potions.GetFilterData();
        return Ok(filterLimits);
    }

    [HttpPost]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PostPotion(PotionDto potion)
    {
        potions.Insert(mapper.Map<Potion>(potion));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PutPotion(PotionDto potion)
    {
        if (potion.PotionId == null)
            return Ok();

        Potion existing = potions.GetById((int)potion.PotionId);
        potion.Update(existing);
        potions.Update(existing);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult DeletePotion(PotionDto potion)
    {
        if (potion.PotionId != null)
            potions.Delete((int)potion.PotionId);
        return Ok();
    }

    [HttpPost("remove")]
    [Authorize(Roles = "Employee")]
    public IActionResult RemovePotions(int[] ids)
    {
        foreach (int id in ids)
        {
            potions.Delete(id);
        }
        return Ok();
    }
}
