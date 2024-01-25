using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class EmployeeControllerTest
{
    TestEmployeeRepository employees;
    IMapper mapper;
    EmployeeController controller;

    public EmployeeControllerTest()
    {
        // Setup
        employees = new TestEmployeeRepository();
        mapper = MapperFaker.MockMapper();
        controller = new EmployeeController(employees, mapper);
    }

    [Fact]
    public void GetEmployee_Returns_Correct_Employee_Data()
    {
        // Execute
        IActionResult result = controller.GetEmployees();
        OkObjectResult ok = result as OkObjectResult;
        List<EmployeeDto> Result = ok.Value as List<EmployeeDto>;
        // Assert
        Assert.Equal(DataFaker.FakeEmployees().Count, Result.Count);
    }

    [Fact]
    public void PostEmployee_Returns_Employee_Data_With_Given_Id()
    {
        int testId = 1000;
        EmployeeDto testEmployee =
            new()
            {
                EmployeeId = testId,
                Username = "TestUsername",
                Password = "TestPassword",
                Name = "Test",
                EmployeeStatusId = 1,
                EmployeePositionId = 1
            };
        // Execute
        controller.PostEmployee(testEmployee);
        Employee newEmployee = employees.GetById(testId);
        // Assert
        Assert.True(testEmployee.Equals(newEmployee));
    }

    [Fact]
    public void PutEmployee_Returns_Employee_With_Updated_Data()
    {
        EmployeeDto gotten = mapper.Map<List<EmployeeDto>>(employees.Get())[0];
        gotten.Name = "Test 2";
        // Execute
        controller.PutEmployee(gotten);
        Employee updated = employees.GetById((int)gotten.EmployeeId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public void DeleteEmployee_Removes_Employee_From_Context()
    {
        EmployeeDto gotten = mapper.Map<List<EmployeeDto>>(employees.Get())[0];
        // Execute
        controller.DeleteEmployee(gotten);
        Employee deleted = employees.GetById((int)gotten.EmployeeId);
        Assert.Null(deleted);
    }
}
