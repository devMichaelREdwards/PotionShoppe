using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EffectController : ControllerBase
{
    private readonly IRepository<Effect> employeeStatuses;
    private readonly IMapper mapper;

    public EffectController(IRepository<Effect> _employeeStatuses, IMapper _mapper)
    {
        employeeStatuses = _employeeStatuses;
        mapper = _mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetEffectes()
    {
        var result = employeeStatuses.Get();
        return Ok(mapper.Map<List<EffectDto>>(result));
    }

    [HttpPost]
    public async Task<IActionResult> PostEffect(EffectDto status)
    {
        employeeStatuses.Insert(mapper.Map<Effect>(status));
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutEffect(EffectDto status)
    {
        employeeStatuses.Update(mapper.Map<Effect>(status));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEffect(EffectDto status)
    {
        if (status.EffectId != null)
            employeeStatuses.Delete((int)status.EffectId);
        return Ok();
    }
}
