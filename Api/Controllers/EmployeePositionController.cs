using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeePositionController : ControllerBase
{
    private readonly IRepository<EmployeePosition> employeePositiones;
    private readonly IMapper mapper;

    public EmployeePositionController(
        IRepository<EmployeePosition> _employeePositiones,
        IMapper _mapper
    )
    {
        employeePositiones = _employeePositiones;
        mapper = _mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeePositiones()
    {
        var result = employeePositiones.Get();
        return Ok(mapper.Map<List<EmployeePositionDto>>(result));
    }

    [HttpPost]
    public async Task<IActionResult> PostEmployeePosition(EmployeePositionDto status)
    {
        employeePositiones.Insert(mapper.Map<EmployeePosition>(status));
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutEmployeePosition(EmployeePositionDto status)
    {
        employeePositiones.Update(mapper.Map<EmployeePosition>(status));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEmployeePosition(EmployeePositionDto status)
    {
        if (status.EmployeePositionId != null)
            employeePositiones.Delete((int)status.EmployeePositionId);
        return Ok();
    }
}
