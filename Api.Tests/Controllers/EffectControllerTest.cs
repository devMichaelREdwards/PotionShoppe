using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class EffectControllerTest
{
    TestEffectRepository effects;
    IMapper mapper;
    EffectController controller;

    public EffectControllerTest()
    {
        // Setup
        effects = new TestEffectRepository();
        mapper = MapperFaker.MockMapper();
        controller = new EffectController(effects, mapper);
    }

    [Fact]
    public void GetEffect_Returns_Correct_Effect_Data()
    {
        // Execute
        IActionResult result = controller.GetEffects();
        OkObjectResult ok = result as OkObjectResult;
        List<EffectDto> statusResult = ok.Value as List<EffectDto>;
        // Assert
        Assert.Equal(DataFaker.FakeEffects().Count, statusResult.Count);
    }

    [Fact]
    public void PostEffect_Returns_Effect_Data_With_Given_Id()
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
        controller.PostEffect(testStatus);
        Effect newStatus = effects.GetById(testId);
        // Assert
        Assert.True(testStatus.Equals(newStatus));
    }

    [Fact]
    public void PutEffect_Returns_Effect_With_Updated_Data()
    {
        EffectDto gotten = mapper.Map<List<EffectDto>>(effects.Get())[0];
        gotten.Duration = 1000;
        gotten.Description = "Test 2";
        // Execute
        controller.PutEffect(gotten);
        Effect updated = effects.GetById((int)gotten.EffectId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public void DeleteEffect_Removes_Effect_From_Context()
    {
        EffectDto gotten = mapper.Map<List<EffectDto>>(effects.Get())[0];
        // Execute
        controller.DeleteEffect(gotten);
        Effect deleted = effects.GetById((int)gotten.EffectId);
        Assert.Null(deleted);
    }
}
