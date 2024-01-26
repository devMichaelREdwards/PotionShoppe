using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class EmployeeStatusControllerTest
{
    TestEmployeeStatusRepository employeeStatuses;
    IMapper mapper;
    EmployeeStatusController controller;

    public EmployeeStatusControllerTest()
    {
        // Setup
        employeeStatuses = new TestEmployeeStatusRepository();
        mapper = MapperFaker.MockMapper();
        controller = new EmployeeStatusController(employeeStatuses, mapper);
    }

    [Fact]
    public async void GetEmployeeStatus_Returns_Correct_EmployeeStatus_Data()
    {
        // Execute
        IActionResult result = await controller.GetEmployeeStatuses();
        OkObjectResult ok = result as OkObjectResult;
        List<EmployeeStatusDto> statusResult = ok.Value as List<EmployeeStatusDto>;
        // Assert
        Assert.Equal(DataFaker.FakeEmployeeStatuses().Count, statusResult.Count);
    }

    [Fact]
    public async void PostEmployeeStatus_Returns_EmployeeStatus_Data_With_Given_Id()
    {
        int testId = 1000;
        EmployeeStatusDto testStatus = new() { EmployeeStatusId = testId, Title = "Test" };
        // Execute
        await controller.PostEmployeeStatus(testStatus);
        EmployeeStatus newStatus = employeeStatuses.GetById(testId);
        // Assert
        Assert.True(testStatus.Equals(newStatus));
    }

    [Fact]
    public async void PutEmployeeStatus_Returns_EmployeeStatus_With_Updated_Data()
    {
        EmployeeStatusDto gotten = mapper.Map<List<EmployeeStatusDto>>(employeeStatuses.Get())[0];
        gotten.Title = "Test 2";
        // Execute
        controller.PutEmployeeStatus(gotten);
        EmployeeStatus updated = employeeStatuses.GetById((int)gotten.EmployeeStatusId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public async void DeleteEmployeeStatus_Removes_EmployeeStatus_From_Context()
    {
        EmployeeStatusDto gotten = mapper.Map<List<EmployeeStatusDto>>(employeeStatuses.Get())[0];
        // Execute
        await controller.DeleteEmployeeStatus(gotten);
        EmployeeStatus deleted = employeeStatuses.GetById((int)gotten.EmployeeStatusId);
        Assert.Null(deleted);
    }
}
