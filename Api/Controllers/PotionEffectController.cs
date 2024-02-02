using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PotionEffectController : ControllerBase
{
    private readonly IRepository<PotionEffect> potionEffects;
    private readonly IMapper mapper;

    public PotionEffectController(IRepository<PotionEffect> _potionEffects, IMapper _mapper)
    {
        potionEffects = _potionEffects;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetPotionEffects()
    {
        var result = potionEffects.Get();
        return Ok(mapper.Map<List<PotionEffectDto>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PostPotionEffect(PotionEffectDto potionEffect)
    {
        potionEffects.Insert(mapper.Map<PotionEffect>(potionEffect));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PutPotionEffect(PotionEffectDto potionEffect)
    {
        if (potionEffect.PotionEffectId == null)
            return Ok();

        PotionEffect existing = potionEffects.GetById((int)potionEffect.PotionEffectId);
        potionEffect.Update(existing);
        potionEffects.Update(existing);

        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult DeletePotionEffect(PotionEffectDto potionEffect)
    {
        if (potionEffect.PotionEffectId != null)
            potionEffects.Delete((int)potionEffect.PotionEffectId);
        return Ok();
    }
}
