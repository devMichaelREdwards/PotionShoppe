using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class EmployeePositionControllerTest
{
    TestEmployeePositionRepository employeePositions;
    IMapper mapper;
    EmployeePositionController controller;

    public EmployeePositionControllerTest()
    {
        // Setup
        employeePositions = new TestEmployeePositionRepository();
        mapper = MapperFaker.MockMapper();
        controller = new EmployeePositionController(employeePositions, mapper);
    }

    [Fact]
    public async void GetEmployeePosition_Returns_Correct_EmployeePosition_Data()
    {
        // Execute
        IActionResult result = await controller.GetEmployeePositiones();
        OkObjectResult ok = result as OkObjectResult;
        List<EmployeePositionDto> statusResult = ok.Value as List<EmployeePositionDto>;
        // Assert
        Assert.Equal(DataFaker.FakeEmployeePositions().Count, statusResult.Count);
    }

    [Fact]
    public async void PostEmployeePosition_Returns_EmployeePosition_Data_With_Given_Id()
    {
        int testId = 1000;
        EmployeePositionDto testPosition = new() { EmployeePositionId = testId, Title = "Test" };
        // Execute
        await controller.PostEmployeePosition(testPosition);
        EmployeePositionDto newPosition = mapper.Map<EmployeePositionDto>(
            employeePositions.GetById(testId)
        );
        // Assert
        Assert.True(newPosition.Equals(testPosition));
    }

    [Fact]
    public async void PutEmployeePosition_Returns_EmployeePosition_With_Updated_Data()
    {
        EmployeePositionDto gotten = mapper.Map<List<EmployeePositionDto>>(employeePositions.Get())[
            0
        ];
        gotten.Title = "Test 2";
        // Execute
        await controller.PutEmployeePosition(gotten);
        EmployeePositionDto updated = mapper.Map<EmployeePositionDto>(
            employeePositions.GetById((int)gotten.EmployeePositionId)
        );
        // Assert
        Assert.True(updated.Equals(gotten));
    }

    [Fact]
    public async void DeleteEmployeePosition_Removes_EmployeePosition_From_Context()
    {
        EmployeePositionDto gotten = mapper.Map<List<EmployeePositionDto>>(employeePositions.Get())[
            0
        ];
        // Execute
        await controller.DeleteEmployeePosition(gotten);
        EmployeePositionDto deleted = mapper.Map<EmployeePositionDto>(
            employeePositions.GetById((int)gotten.EmployeePositionId)
        );
        Assert.Null(deleted);
    }
}
