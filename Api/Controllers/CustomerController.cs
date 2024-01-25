using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly IRepository<Customer> customers;
    private readonly IMapper mapper;

    public CustomerController(IRepository<Customer> _customers, IMapper _mapper)
    {
        customers = _customers;
        mapper = _mapper;
    }

    [HttpGet]
    public IActionResult GetCustomers()
    {
        var result = customers.Get();
        return Ok(mapper.Map<List<CustomerDto>>(result));
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
        if (customer.CustomerId == null) return Ok();

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
