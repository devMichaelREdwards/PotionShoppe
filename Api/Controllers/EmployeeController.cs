using Api.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly PotionShoppeContext context;

    public EmployeeController(PotionShoppeContext _context)
    {
        context = _context;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        return Ok(
            await context.Employees
                .Include(e => e.EmployeeStatus)
                .Include(e => e.Position)
                .ToListAsync()
        );
    }
}
