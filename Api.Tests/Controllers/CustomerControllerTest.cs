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
    public void GetCustomer_Returns_Correct_Customer_Data()
    {
        // Execute
        IActionResult result = controller.GetCustomers();
        OkObjectResult ok = result as OkObjectResult;
        List<CustomerDto> Result = ok.Value as List<CustomerDto>;
        // Assert
        Assert.Equal(DataFaker.FakeCustomers().Count, Result.Count);
    }

    [Fact]
    public void PostCustomer_Returns_Customer_Data_With_Given_Id()
    {
        int testId = 1000;
        CustomerDto test =
            new()
            {
                CustomerId = testId,
                FirstName = "TestFirst",
                LastName = "TestLast",
                CustomerStatusId = 1
            };
        // Execute
        controller.PostCustomer(test);
        Customer newCustomer = customers.GetById(testId);
        // Assert
        Assert.True(test.Equals(newCustomer));
    }

    [Fact]
    public void PutCustomer_Returns_Customer_With_Updated_Data()
    {
        CustomerDto gotten = mapper.Map<List<CustomerDto>>(customers.Get())[0];
        gotten.FirstName = "TestFirst2";
        gotten.LastName = "TestLast2";
        // Execute
        controller.PutCustomer(gotten);
        Customer updated = customers.GetById((int)gotten.CustomerId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public void DeleteCustomer_Removes_Customer_From_Context()
    {
        CustomerDto gotten = mapper.Map<List<CustomerDto>>(customers.Get())[0];
        // Execute
        controller.DeleteCustomer(gotten);
        Customer deleted = customers.GetById((int)gotten.CustomerId);
        Assert.Null(deleted);
    }
}
