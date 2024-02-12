using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IRepository<Employee> employees;
    private readonly IMapper mapper;

    public EmployeeController(IRepository<Employee> _employees, IMapper _mapper)
    {
        employees = _employees;
        mapper = _mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetEmployees()
    {
        var result = employees.Get();
        return Ok(mapper.Map<List<EmployeeDto>>(result));
    }

    [HttpGet("employee-listing")]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult GetEmployeeListing()
    {
        var result = employees.GetListing();
        return Ok(mapper.Map<List<EmployeeListing>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Owner")]
    public IActionResult PostEmployee(EmployeeDto employee)
    {
        employees.Insert(mapper.Map<Employee>(employee));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Owner")]
    public IActionResult PutEmployee(EmployeeDto employee)
    {
        if (employee.EmployeeId == null)
            return Ok();

        Employee existing = employees.GetById((int)employee.EmployeeId);
        employee.Update(existing);
        employees.Update(existing);

        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Owner")]
    public IActionResult DeleteEmployee(EmployeeDto employee)
    {
        if (employee.EmployeeId != null)
            employees.Delete((int)employee.EmployeeId);
        return Ok();
    }
}
