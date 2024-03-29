using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult GetEmployeePositions()
    {
        var result = employeePositions.Get();
        return Ok(mapper.Map<List<EmployeePositionDto>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Owner")]
    public IActionResult PostEmployeePosition(EmployeePositionDto employeePosition)
    {
        employeePositions.Insert(mapper.Map<EmployeePosition>(employeePosition));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Owner")]
    public IActionResult PutEmployeePosition(EmployeePositionDto employeePosition)
    {
        if (employeePosition.EmployeePositionId == null)
            return Ok();
        EmployeePosition existing = employeePositions.GetById((int)employeePosition.EmployeePositionId);
        employeePosition.Update(existing);
        employeePositions.Update(existing);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Owner")]
    public IActionResult DeleteEmployeePosition(EmployeePositionDto employeePosition)
    {
        if (employeePosition.EmployeePositionId != null)
            employeePositions.Delete((int)employeePosition.EmployeePositionId);
        return Ok();
    }
}
