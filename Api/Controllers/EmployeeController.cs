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
    private readonly PotionShoppeContext context;
    private readonly IMapper mapper;

    public EmployeeController(PotionShoppeContext _context, IMapper _mapper)
    {
        context = _context;
        mapper = _mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        var employees = await context.Employees
            .Include(e => e.EmployeeStatus)
            .Include(e => e.EmployeePosition)
            .ToListAsync();

        return Ok(mapper.Map<List<EmployeeDto>>(employees));
    }
}
