using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class CustomerControllerTest
{
    TestCustomerRepository customers;
    IMapper mapper;
    CustomerController controller;

    public CustomerControllerTest()
    {
        // Setup
        customers = new TestCustomerRepository();
        mapper = MapperFaker.MockMapper();
        controller = new CustomerController(customers, mapper);
    }

    [Fact]
    public async void GetCustomer_Returns_Correct_Customer_Data()
    {
        // Execute
        IActionResult result = await controller.GetCustomers();
        OkObjectResult ok = result as OkObjectResult;
        List<CustomerDto> Result = ok.Value as List<CustomerDto>;
        // Assert
        Assert.Equal(DataFaker.FakeCustomers().Count, Result.Count);
    }

    [Fact]
    public async void PostCustomer_Returns_Customer_Data_With_Given_Id()
    {
        int testId = 1000;
        CustomerDto test = new() { CustomerId = testId, Name = "Test", CustomerStatusId = 1 };
        // Execute
        await controller.PostCustomer(test);
        Customer newCustomer = customers.GetById(testId);
        // Assert
        Assert.True(test.Equals(newCustomer));
    }

    [Fact]
    public async void PutCustomer_Returns_Customer_With_Updated_Data()
    {
        CustomerDto gotten = mapper.Map<List<CustomerDto>>(customers.Get())[0];
        gotten.Name = "Test 2";
        // Execute
        await controller.PutCustomer(gotten);
        Customer updated = customers.GetById((int)gotten.CustomerId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public async void DeleteCustomer_Removes_Customer_From_Context()
    {
        CustomerDto gotten = mapper.Map<List<CustomerDto>>(customers.Get())[0];
        // Execute
        await controller.DeleteCustomer(gotten);
        CustomerDto deleted = mapper.Map<CustomerDto>(
            customers.GetById((int)gotten.CustomerId)
        );
        Assert.Null(deleted);
    }
}
