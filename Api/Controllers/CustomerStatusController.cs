using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerStatusController : ControllerBase
{
    private readonly IRepository<CustomerStatus> employeeStatuses;
    private readonly IMapper mapper;

    public CustomerStatusController(IRepository<CustomerStatus> _employeeStatuses, IMapper _mapper)
    {
        employeeStatuses = _employeeStatuses;
        mapper = _mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetCustomerStatuses()
    {
        var result = employeeStatuses.Get();
        return Ok(mapper.Map<List<CustomerStatusDto>>(result));
    }

    [HttpPost]
    public async Task<IActionResult> PostCustomerStatus(CustomerStatusDto status)
    {
        employeeStatuses.Insert(mapper.Map<CustomerStatus>(status));
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutCustomerStatus(CustomerStatusDto status)
    {
        employeeStatuses.Update(mapper.Map<CustomerStatus>(status));
        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCustomerStatus(CustomerStatusDto status)
    {
        if (status.CustomerStatusId != null)
            employeeStatuses.Delete((int)status.CustomerStatusId);
        return Ok();
    }
}
