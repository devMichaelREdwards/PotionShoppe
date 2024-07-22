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
    private readonly IListingRepository<Customer> customers;
    private readonly IMapper mapper;

    public CustomerController(IListingRepository<Customer> _customers, IMapper _mapper)
    {
        customers = _customers;
        mapper = _mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetCustomers()
    {
        var result = customers.Get();
        return Ok(mapper.Map<List<CustomerDto>>(result));
    }

    [HttpGet("listing")]
    [Authorize(Roles = "Employee")]
    public IActionResult GetCustomerListing()
    {
        CustomerFilter? filter = CustomerFilter.BuildFilter(Request.Query);
        Pagination? page = Pagination.BuildFilter(Request.Query);
        var result = customers.GetListing(filter, page);
        return Ok(mapper.Map<List<CustomerListing>>(result));
    }

    [HttpPost]
    public IActionResult PostCustomer(CustomerDto customer)
    {
        customers.Insert(mapper.Map<Customer>(customer));
        return Ok();
    }

    [HttpPut]
    public IActionResult PutCustomer(CustomerDto customer)
    {
        if (customer.CustomerId == null)
            return Ok();

        Customer existing = customers.GetById((int)customer.CustomerId);
        customer.Update(existing);
        customers.Update(existing);

        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteCustomer(CustomerDto customer)
    {
        if (customer.CustomerId != null)
            customers.Delete((int)customer.CustomerId);
        return Ok();
    }
}
