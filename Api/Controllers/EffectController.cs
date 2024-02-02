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
    private readonly IRepository<Effect> effects;
    private readonly IMapper mapper;

    public EffectController(IRepository<Effect> _effects, IMapper _mapper)
    {
        effects = _effects;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetEffects()
    {
        var result = effects.Get();
        return Ok(mapper.Map<List<EffectDto>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PostEffect(EffectDto effect)
    {
        effects.Insert(mapper.Map<Effect>(effect));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee,Owner")]
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
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult DeleteEffect(EffectDto effect)
    {
        if (effect.EffectId != null)
            effects.Delete((int)effect.EffectId);
        return Ok();
    }
}
