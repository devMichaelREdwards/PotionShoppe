using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class EffectControllerTest
{
    TestEffectRepository employeeStatuses;
    IMapper mapper;
    EffectController controller;

    public EffectControllerTest()
    {
        // Setup
        employeeStatuses = new TestEffectRepository();
        mapper = MapperFaker.MockMapper();
        controller = new EffectController(employeeStatuses, mapper);
    }

    [Fact]
    public async void GetEffect_Returns_Correct_Effect_Data()
    {
        // Execute
        IActionResult result = await controller.GetEffectes();
        OkObjectResult ok = result as OkObjectResult;
        List<EffectDto> statusResult = ok.Value as List<EffectDto>;
        // Assert
        Assert.Equal(DataFaker.FakeEffects().Count, statusResult.Count);
    }

    [Fact]
    public async void PostEffect_Returns_Effect_Data_With_Given_Id()
    {
        int testId = 1000;
        EffectDto testStatus =
            new()
            {
                EffectId = testId,
                Duration = 50,
                Description = "Test"
            };
        // Execute
        await controller.PostEffect(testStatus);
        EffectDto newStatus = mapper.Map<EffectDto>(employeeStatuses.GetById(testId));
        // Assert
        Assert.True(newStatus.Equals(testStatus));
    }

    [Fact]
    public async void PutEffect_Returns_Effect_With_Updated_Data()
    {
        EffectDto gotten = mapper.Map<List<EffectDto>>(employeeStatuses.Get())[0];
        gotten.Duration = 1000;
        gotten.Description = "Test 2";
        // Execute
        await controller.PutEffect(gotten);
        EffectDto updated = mapper.Map<EffectDto>(employeeStatuses.GetById((int)gotten.EffectId));
        // Assert
        Assert.True(updated.Equals(gotten));
    }

    [Fact]
    public async void DeleteEffect_Removes_Effect_From_Context()
    {
        EffectDto gotten = mapper.Map<List<EffectDto>>(employeeStatuses.Get())[0];
        // Execute
        await controller.DeleteEffect(gotten);
        EffectDto deleted = mapper.Map<EffectDto>(employeeStatuses.GetById((int)gotten.EffectId));
        Assert.Null(deleted);
    }
}
