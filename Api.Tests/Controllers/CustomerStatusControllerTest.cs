using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class CustomerStatusControllerTest
{
    TestCustomerStatusRepository customerStatuses;
    IMapper mapper;
    CustomerStatusController controller;

    public CustomerStatusControllerTest()
    {
        // Setup
        customerStatuses = new TestCustomerStatusRepository();
        mapper = MapperFaker.MockMapper();
        controller = new CustomerStatusController(customerStatuses, mapper);
    }

    [Fact]
    public async void GetCustomerStatus_Returns_Correct_CustomerStatus_Data()
    {
        // Execute
        IActionResult result = controller.GetCustomerStatuses();
        OkObjectResult ok = result as OkObjectResult;
        List<CustomerStatusDto> statusResult = ok.Value as List<CustomerStatusDto>;
        // Assert
        Assert.Equal(DataFaker.FakeCustomerStatuses().Count, statusResult.Count);
    }

    [Fact]
    public async void PostCustomerStatus_Returns_CustomerStatus_Data_With_Given_Id()
    {
        int testId = 1000;
        CustomerStatusDto testStatus = new() { CustomerStatusId = testId, Title = "Test" };
        // Execute
        controller.PostCustomerStatus(testStatus);
        CustomerStatus newStatus = customerStatuses.GetById(testId);

        // Assert
        Assert.True(testStatus.Equals(newStatus));
    }

    [Fact]
    public async void PutCustomerStatus_Returns_CustomerStatus_With_Updated_Data()
    {
        CustomerStatusDto gotten = mapper.Map<List<CustomerStatusDto>>(customerStatuses.Get())[0];
        gotten.Title = "Test 2";
        // Execute
        controller.PutCustomerStatus(gotten);
        CustomerStatus updated = customerStatuses.GetById((int)gotten.CustomerStatusId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public async void DeleteCustomerStatus_Removes_CustomerStatus_From_Context()
    {
        CustomerStatusDto gotten = mapper.Map<List<CustomerStatusDto>>(customerStatuses.Get())[0];
        // Execute
        controller.DeleteCustomerStatus(gotten);
        CustomerStatusDto deleted = mapper.Map<CustomerStatusDto>(
            customerStatuses.GetById((int)gotten.CustomerStatusId)
        );
        Assert.Null(deleted);
    }
}
