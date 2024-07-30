using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IListingRepository<Customer> _customers;
    private readonly IRepository<CustomerStatus> _customerStatuses;
    private readonly IMapper _mapper;

    public CustomerController(IListingRepository<Customer> customers, IRepository<CustomerStatus> customerStatuses, IMapper mapper)
    {
        _customers = customers;
        _customerStatuses = customerStatuses;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetCustomers()
    {
        var result = _customers.Get();
        return Ok(_mapper.Map<List<CustomerDto>>(result));
    }

    [HttpGet("listing")]
    [Authorize(Roles = "Employee")]
    public IActionResult GetCustomerListing()
    {
        CustomerFilter? filter = CustomerFilter.BuildFilter(Request.Query);
        Pagination? page = Pagination.BuildFilter(Request.Query);
        var result = _customers.GetListing(filter, page);
        return Ok(_mapper.Map<List<CustomerListing>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public IActionResult PostCustomer(CustomerDto customer)
    {
        _customers.Insert(_mapper.Map<Customer>(customer));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee")]
    public IActionResult PutCustomer(CustomerDto customer)
    {
        if (customer.CustomerId == null)
            return Ok();

        Customer existing = _customers.GetById((int)customer.CustomerId);
        customer.Update(existing);
        _customers.Update(existing);

        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Owner")]
    public IActionResult DeleteCustomer(CustomerDto customer)
    {
        if (customer.CustomerId != null)
            _customers.Delete((int)customer.CustomerId);
        return Ok();
    }

    [HttpPost("toggle")]
    [Authorize(Roles = "Employee")]
    public IActionResult ToggleCustomerStatus(CustomerDto toggled)
    {
        if (toggled.CustomerId is null)
            return BadRequest();

        Customer? Customer = _customers.GetById(toggled.CustomerId ?? 0);
        if (Customer is null)
            return BadRequest();

        int activeStatusId = (_customerStatuses as CustomerStatusRepository).GetFirstByStatus("ACTIVE").CustomerStatusId;
        int bannedStatusId = (_customerStatuses as CustomerStatusRepository).GetFirstByStatus("BANNED").CustomerStatusId;
        int newStatusId = 0;
        if (Customer.CustomerStatusId == activeStatusId)
        {
            Customer.CustomerStatusId = bannedStatusId;
        }
        else
        {
            Customer.CustomerStatusId = activeStatusId;
        }
        _customers.Update(Customer);
        return Ok();
    }

}
