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
    public async Task<IActionResult> GetCustomers()
    {
        var result = customers.Get();
        return Ok(mapper.Map<List<CustomerDto>>(result));
    }

    [HttpPost]
    public async Task<IActionResult> PostCustomer(CustomerDto customer)
    {
        Customer newCustomer = new Customer()
        {
            Username = customer.Username,
            Password = customer.Password,
            Name = customer.Name,
            CustomerStatusId = customer.CustomerStatusId
        };
        customers.Insert(newCustomer);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> PutCustomer(CustomerDto customer)
    {
        if (customer.CustomerId != null)
        {
            Customer existing = customers.GetById((int)customer.CustomerId);
            existing.Name = customer.Name ?? existing.Name;
            existing.CustomerStatusId = customer.CustomerStatusId ?? existing.CustomerStatusId;
            customers.Update(existing);
        }

        return Ok();
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteCustomer(CustomerDto customer)
    {
        if (customer.CustomerId != null)
            customers.Delete((int)customer.CustomerId);
        return Ok();
    }
}
