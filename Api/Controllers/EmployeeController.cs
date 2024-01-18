using Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employees = new List<Employee>
        {
            new Employee()
            {
                EmployeeId = 1,
                EmployeeStatusId = new EmployeeStatus() { EmployeeStatusId = 1, Title = "Active" },
                EmployeePositionId = new EmployeePosition()
                {
                    EmployeePositionId = 1,
                    Title = "Owner"
                }
            }
        };

        return Ok(employees);
    }
}
