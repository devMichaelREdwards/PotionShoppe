using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EffectController : ControllerBase
{
    private readonly IFilterRepository<Effect> effects;
    private readonly IMapper mapper;

    public EffectController(IFilterRepository<Effect> _effects, IMapper _mapper)
    {
        effects = _effects;
        mapper = _mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetEffects()
    {
        var result = effects.Get();
        return Ok(mapper.Map<List<EffectDto>>(result));
    }

    [HttpGet("listing")]
    public IActionResult GetEffectListing()
    {
        EffectFilter? filter = EffectFilter.BuildFilter(Request.Query);
        Pagination? page = Pagination.BuildFilter(Request.Query);
        var result = effects.GetListing(filter, page);
        return Ok(mapper.Map<List<EffectListing>>(result));
    }

    [HttpGet("filters")]
    public IActionResult GetFilterInfo()
    {
        EffectFilter filterLimits = (EffectFilter)effects.GetFilterData();
        return Ok(filterLimits);
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public IActionResult PostEffect(EffectDto effect)
    {
        effects.Insert(mapper.Map<Effect>(effect));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee")]
    public IActionResult PutEffect(EffectDto effect)
    {
        if (effect.EffectId == null)
            return Ok();
        Effect existing = effects.GetById((int)effect.EffectId);
        effect.Update(existing);
        effects.Update(existing);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Employee")]
    public IActionResult DeleteEffect(EffectDto effect)
    {
        if (effect.EffectId != null)
            effects.Delete((int)effect.EffectId);
        return Ok();
    }

    [HttpPost("remove")]
    [Authorize(Roles = "Employee")]
    public IActionResult RemoveEffects(int[] ids)
    {
        foreach (int id in ids)
        {
            effects.Delete(id);
        }
        return Ok();
    }
}
