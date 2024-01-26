using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PotionController : ControllerBase
{
    private readonly IRepository<Potion> potions;
    private readonly IMapper mapper;

    public PotionController(IRepository<Potion> _potions, IMapper _mapper)
    {
        potions = _potions;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetPotions()
    {
        var result = potions.Get();
        return Ok(mapper.Map<List<PotionDto>>(result));
    }

    [HttpPost]
    public IActionResult PostPotion(PotionDto customer)
    {
        potions.Insert(mapper.Map<Potion>(customer));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutPotion(PotionDto customer)
    {
        if (customer.PotionId == null)
            return Ok();

        Potion existing = potions.GetById((int)customer.PotionId);
        customer.Update(existing);
        potions.Update(existing);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeletePotion(PotionDto customer)
    {
        if (customer.PotionId != null)
            potions.Delete((int)customer.PotionId);
        return Ok();
    }
}
