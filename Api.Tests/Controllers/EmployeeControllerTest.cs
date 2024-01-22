using Api.Controllers;
using Api.Data;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class EmployeeControllerTest
{
    TestEmployeeRepository employees;
    IMapper mapper;

    public EmployeeControllerTest()
    {
        // Setup
        employees = new TestEmployeeRepository();
        mapper = MapperFaker.MockMapper();
    }

    [Fact]
    public async void GetEmployees_Returns_Correct_Employee_Data()
    {
        // Execute
        EmployeeController controller = new EmployeeController(employees, mapper);
        IActionResult result = await controller.GetEmployees();

        OkObjectResult ok = result as OkObjectResult;
        List<EmployeeDto> employeesResult = ok.Value as List<EmployeeDto>;
        // Assert
        Assert.Equal(DataFaker.FakeEmployees().Count, employeesResult.Count);
    }
}
