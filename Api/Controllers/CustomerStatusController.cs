using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerStatusController : ControllerBase
{
    private readonly IRepository<CustomerStatus> customerStatuses;
    private readonly IMapper mapper;

    public CustomerStatusController(IRepository<CustomerStatus> _customerStatuses, IMapper _mapper)
    {
        customerStatuses = _customerStatuses;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetCustomerStatuses()
    {
        var result = customerStatuses.Get();
        return Ok(mapper.Map<List<CustomerStatusDto>>(result));
    }

    [HttpPost]
    public IActionResult PostCustomerStatus(CustomerStatusDto status)
    {
        customerStatuses.Insert(mapper.Map<CustomerStatus>(status));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutCustomerStatus(CustomerStatusDto status)
    {
        if (status.CustomerStatusId == null)
            return Ok();
        CustomerStatus existing = customerStatuses.GetById((int)status.CustomerStatusId);
        status.Update(existing);
        customerStatuses.Update(existing);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteCustomerStatus(CustomerStatusDto status)
    {
        if (status.CustomerStatusId != null)
            customerStatuses.Delete((int)status.CustomerStatusId);
        return Ok();
    }
}
