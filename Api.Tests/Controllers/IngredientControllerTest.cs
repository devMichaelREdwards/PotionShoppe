using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class IngredientControllerTest
{
    TestIngredientRepository ingredients;
    TestEffectRepository effects;
    IMapper mapper;
    IngredientController controller;

    public IngredientControllerTest()
    {
        // Setup
        ingredients = new TestIngredientRepository();
        effects = new TestEffectRepository();
        mapper = MapperFaker.MockMapper();
        controller = new IngredientController(ingredients, effects, mapper);
    }

    [Fact]
    public void GetIngredient_Returns_Correct_Ingredient_Data()
    {
        // Execute
        IActionResult result = controller.GetIngredients();
        OkObjectResult ok = result as OkObjectResult;
        List<IngredientDto> Result = ok.Value as List<IngredientDto>;
        // Assert
        Assert.Equal(DataFaker.FakeIngredients().Count, Result.Count);
    }

    [Fact]
    public void PostIngredient_Returns_Ingredient_Data_With_Given_Id()
    {
        int testId = 1000;
        IngredientDto test =
            new()
            {
                IngredientId = testId,
                IngredientCategoryId = 1,
                Name = "Test",
                Description = "Test Desc",
                EffectId = 1,
                Price = 50,
                Cost = 25,
                CurrentStock = 100,
                Image = ""

            };
        // Execute
        controller.PostIngredient(test);
        Ingredient newIngredient = ingredients.GetById(testId);
        // Assert
        Assert.True(test.Equals(newIngredient));
    }

    [Fact]
    public void PutIngredient_Returns_Ingredient_With_Updated_Data()
    {
        IngredientDto gotten = mapper.Map<List<IngredientDto>>(ingredients.Get())[0];
        gotten.Name = "Test 2";
        // Execute
        controller.PutIngredient(gotten);
        Ingredient updated = ingredients.GetById((int)gotten.IngredientId);
        // Assert
        Assert.True(gotten.Name == updated.Product.Name); // maybe wrote full update tests in future
    }

    [Fact]
    public void DeleteIngredient_Removes_Ingredient_From_Context()
    {
        IngredientDto gotten = mapper.Map<List<IngredientDto>>(ingredients.Get())[0];
        // Execute
        controller.DeleteIngredient(gotten);
        Ingredient deleted = ingredients.GetById((int)gotten.IngredientId);
        Assert.Null(deleted);
    }
}
