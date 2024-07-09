using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class PotionControllerTest
{
    TestPotionRepository potions;
    IMapper mapper;
    PotionController controller;

    public PotionControllerTest()
    {
        // Setup
        potions = new TestPotionRepository();
        mapper = MapperFaker.MockMapper();
        controller = new PotionController(potions, null, mapper);
    }

    [Fact]
    public void GetPotion_Returns_Correct_Potion_Data()
    {
        // Execute
        IActionResult result = controller.GetPotions();
        OkObjectResult ok = result as OkObjectResult;
        List<PotionDto> Result = ok.Value as List<PotionDto>;
        // Assert
        Assert.Equal(DataFaker.FakePotions().Count, Result.Count);
    }

    [Fact]
    public void PostPotion_Returns_Potion_Data_With_Given_Id()
    {
        int testId = 1000;
        PotionDto test =
            new()
            {
                PotionId = testId,
                Name = "Test"
            };
        // Execute
        controller.PostPotion(test);
        Potion newPotion = potions.GetById(testId);
        // Assert
        Assert.True(test.Equals(newPotion));
    }

    [Fact]
    public void PutPotion_Returns_Potion_With_Updated_Data()
    {
        PotionDto gotten = mapper.Map<List<PotionDto>>(potions.Get())[0];
        gotten.Name = "Test 2";
        // Execute
        controller.PutPotion(gotten);
        Potion updated = potions.GetById((int)gotten.PotionId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public void DeletePotion_Removes_Potion_From_Context()
    {
        PotionDto gotten = mapper.Map<List<PotionDto>>(potions.Get())[0];
        // Execute
        controller.DeletePotion(gotten);
        Potion deleted = potions.GetById((int)gotten.PotionId);
        Assert.Null(deleted);
    }
}
