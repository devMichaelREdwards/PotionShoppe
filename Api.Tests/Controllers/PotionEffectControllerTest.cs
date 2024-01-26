using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class PotionEffectControllerTest
{
    TestPotionEffectRepository potions;
    IMapper mapper;
    PotionEffectController controller;

    public PotionEffectControllerTest()
    {
        // Setup
        potions = new TestPotionEffectRepository();
        mapper = MapperFaker.MockMapper();
        controller = new PotionEffectController(potions, mapper);
    }

    [Fact]
    public void GetPotionEffect_Returns_Correct_PotionEffect_Data()
    {
        // Execute
        IActionResult result = controller.GetPotionEffects();
        OkObjectResult ok = result as OkObjectResult;
        List<PotionEffectDto> Result = ok.Value as List<PotionEffectDto>;
        // Assert
        Assert.Equal(DataFaker.FakePotionEffects().Count, Result.Count);
    }

    [Fact]
    public void PostPotionEffect_Returns_PotionEffect_Data_With_Given_Id()
    {
        int testId = 1000;
        PotionEffectDto test = new() { PotionEffectId = testId, EffectId = 2 };
        // Execute
        controller.PostPotionEffect(test);
        PotionEffect newPotionEffect = potions.GetById(testId);
        // Assert
        Assert.True(test.Equals(newPotionEffect));
    }

    [Fact]
    public void PutPotionEffect_Returns_PotionEffect_With_Updated_Data()
    {
        PotionEffectDto gotten = mapper.Map<List<PotionEffectDto>>(potions.Get())[0];
        gotten.EffectId = 2;
        // Execute
        controller.PutPotionEffect(gotten);
        PotionEffect updated = potions.GetById((int)gotten.PotionEffectId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public void DeletePotionEffect_Removes_PotionEffect_From_Context()
    {
        PotionEffectDto gotten = mapper.Map<List<PotionEffectDto>>(potions.Get())[0];
        // Execute
        controller.DeletePotionEffect(gotten);
        PotionEffect deleted = potions.GetById((int)gotten.PotionEffectId);
        Assert.Null(deleted);
    }
}
