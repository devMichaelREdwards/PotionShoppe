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
    public IActionResult PostCustomerStatus(CustomerStatusDto customerStatus)
    {
        customerStatuses.Insert(mapper.Map<CustomerStatus>(customerStatus));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutCustomerStatus(CustomerStatusDto customerStatus)
    {
        if (customerStatus.CustomerStatusId == null)
            return Ok();
        CustomerStatus existing = customerStatuses.GetById((int)customerStatus.CustomerStatusId);
        customerStatus.Update(existing);
        customerStatuses.Update(existing);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteCustomerStatus(CustomerStatusDto customerStatus)
    {
        if (customerStatus.CustomerStatusId != null)
            customerStatuses.Delete((int)customerStatus.CustomerStatusId);
        return Ok();
    }
}
