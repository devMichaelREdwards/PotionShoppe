using Api.Classes;
using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EffectController : ControllerBase
{
    private readonly IListingRepository<Effect> _effects;
    private readonly IMapper _mapper;

    public EffectController(IListingRepository<Effect> effects, IMapper mapper)
    {
        _effects = effects;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetEffects()
    {
        var result = _effects.Get();
        return Ok(_mapper.Map<List<EffectDto>>(result));
    }

    [HttpGet("{id}")]
    [Authorize(Roles = "Employee")]
    public IActionResult GetEffect(int? id)
    {
        if (id == null) return BadRequest("Invalid request");
        var result = _effects.GetById((int)id);
        if (result == null) return BadRequest("No resource found");
        return Ok(_mapper.Map<EffectDto>(result));
    }

    [HttpGet("listing/{id}")]
    public IActionResult GetEffectListing(int? id)
    {
        if (id == null) return BadRequest("Invalid request");
        var result = _effects.GetById((int)id);
        if (result == null) return BadRequest("No resource found");
        return Ok(_mapper.Map<EffectListing>(result));
    }

    [HttpGet("listing")]
    public IActionResult GetEffectListing()
    {
        EffectFilter? filter = EffectFilter.BuildFilter(Request.Query);
        Pagination? page = Pagination.BuildFilter(Request.Query);
        SortOrder? sortOrder = SortOrder.BuildFilter(Request.Query);
        var result = _effects.GetListing(filter, page, sortOrder);
        return Ok(_mapper.Map<List<EffectListing>>(result));
    }

    [HttpGet("filters")]
    public IActionResult GetFilterInfo()
    {
        EffectFilter filterLimits = (EffectFilter)_effects.GetFilterData();
        return Ok(filterLimits);
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public IActionResult PostEffect(EffectDto effect)
    {
        ErrorCollection errors = SetErrors(effect);
        if (errors.Error) return BadRequest(errors);
        _effects.Insert(_mapper.Map<Effect>(effect));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee")]
    public IActionResult PutEffect(EffectDto effect)
    {
        ErrorCollection errors = SetErrors(effect, true);
        Effect? existing = _effects.GetById((int)effect.EffectId);
        if (existing is null)
        {
            errors.Add("exist", "This effect was not found. Please refresh the listing.");
        }
        if (errors.Error) return BadRequest(errors);
        effect.Update(existing!); // Set data in collected DTO
        _effects.Update(existing!); // Save new DTO to database
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Employee")]
    public IActionResult DeleteEffect(EffectDto effect)
    {
        if (effect.EffectId != null)
            _effects.Delete((int)effect.EffectId);
        return Ok();
    }

    [HttpPost("remove")]
    [Authorize(Roles = "Employee")]
    public IActionResult RemoveEffects(int[] ids)
    {
        foreach (int id in ids)
        {
            _effects.Delete(id);
        }
        return Ok();
    }

    private ErrorCollection SetErrors(EffectDto effect, bool withId = false)
    {
        ErrorCollection errors = new();
        if (withId && effect.EffectId == null)
        {
            errors.Add("id", "Invalid Effect ID sent with request.");
        }
        if (effect.Name.Length < 3)
        {
            errors.Add("name", "Name must be 3 characters.");
        }

        if (effect.Value < 0)
        {
            errors.Add("value", "Value must be positive.");
        }

        if (effect.Duration < 0)
        {
            errors.Add("duration", "Duration must be positive.");
        }

        return errors;
    }
}
