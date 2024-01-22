using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeStatusController : ControllerBase
{
    private readonly IRepository<EmployeeStatus> employeeStatuses;
    private readonly IMapper mapper;

    public EmployeeStatusController(IRepository<EmployeeStatus> _employeeStatuses, IMapper _mapper)
    {
        employeeStatuses = _employeeStatuses;
        mapper = _mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployeeStatuses()
    {
        var result = employeeStatuses.Get();
        return Ok(mapper.Map<List<EmployeeStatusDto>>(result));
    }

    [HttpPost]
    public async Task<IActionResult> PostEmployeeStatus(EmployeeStatusDto status)
    {
        employeeStatuses.Insert(mapper.Map<EmployeeStatus>(status));
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutEmployeeStatus(EmployeeStatusDto status)
    {
        employeeStatuses.Update(mapper.Map<EmployeeStatus>(status));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEmployeeStatus(EmployeeStatusDto status)
    {
        if (status.EmployeeStatusId != null)
            employeeStatuses.Delete((int)status.EmployeeStatusId);
        return Ok();
    }
}
