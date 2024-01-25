using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeePositionController : ControllerBase
{
    private readonly IRepository<EmployeePosition> employeePositions;
    private readonly IMapper mapper;

    public EmployeePositionController(
        IRepository<EmployeePosition> _employeePositions,
        IMapper _mapper
    )
    {
        employeePositions = _employeePositions;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetEmployeePositiones()
    {
        var result = employeePositions.Get();
        return Ok(mapper.Map<List<EmployeePositionDto>>(result));
    }

    [HttpPost]
    public IActionResult PostEmployeePosition(EmployeePositionDto position)
    {
        employeePositions.Insert(mapper.Map<EmployeePosition>(position));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutEmployeePosition(EmployeePositionDto position)
    {
        if (position.EmployeePositionId == null)
            return Ok();
        EmployeePosition existing = employeePositions.GetById((int)position.EmployeePositionId);
        position.Update(existing);
        employeePositions.Update(existing);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteEmployeePosition(EmployeePositionDto position)
    {
        if (position.EmployeePositionId != null)
            employeePositions.Delete((int)position.EmployeePositionId);
        return Ok();
    }
}
