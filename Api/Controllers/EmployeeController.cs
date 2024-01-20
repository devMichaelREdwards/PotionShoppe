using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public async Task<IActionResult> GetEmployees()
    {
        var result = employees.Get();
        return Ok(mapper.Map<List<EmployeeDto>>(result));
    }
}
