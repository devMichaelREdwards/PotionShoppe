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
    public async Task<IActionResult> PostEmployeeStatus(EmployeeStatusDto employeeStatus)
    {
        employeeStatuses.Insert(mapper.Map<EmployeeStatus>(employeeStatus));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutEmployeeStatus(EmployeeStatusDto employeeStatus)
    {
        if (employeeStatus.EmployeeStatusId == null)
            return Ok();
        EmployeeStatus existing = employeeStatuses.GetById((int)employeeStatus.EmployeeStatusId);
        employeeStatus.Update(existing);
        employeeStatuses.Update(existing);
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteEmployeeStatus(EmployeeStatusDto employeeStatus)
    {
        if (employeeStatus.EmployeeStatusId != null)
            employeeStatuses.Delete((int)employeeStatus.EmployeeStatusId);
        return Ok();
    }
}
