using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class IngredientCategoryControllerTest
{
    TestIngredientCategoryRepository ingredientCategories;
    IMapper mapper;
    IngredientCategoryController controller;

    public IngredientCategoryControllerTest()
    {
        // Setup
        ingredientCategories = new TestIngredientCategoryRepository();
        mapper = MapperFaker.MockMapper();
        controller = new IngredientCategoryController(ingredientCategories, mapper);
    }

    [Fact]
    public async void GetIngredientCategory_Returns_Correct_IngredientCategory_Data()
    {
        // Execute
        IActionResult result = controller.GetIngredientCategories();
        OkObjectResult ok = result as OkObjectResult;
        List<IngredientCategoryDto> statusResult = ok.Value as List<IngredientCategoryDto>;
        // Assert
        Assert.Equal(DataFaker.FakeIngredientCategories().Count, statusResult.Count);
    }

    [Fact]
    public async void PostIngredientCategory_Returns_IngredientCategory_Data_With_Given_Id()
    {
        int testId = 1000;
        IngredientCategoryDto testStatus = new() { IngredientCategoryId = testId, Title = "Test" };
        // Execute
        controller.PostIngredientCategory(testStatus);
        IngredientCategory newStatus = ingredientCategories.GetById(testId);

        // Assert
        Assert.True(testStatus.Equals(newStatus));
    }

    [Fact]
    public async void PutIngredientCategory_Returns_IngredientCategory_With_Updated_Data()
    {
        IngredientCategoryDto gotten = mapper.Map<List<IngredientCategoryDto>>(ingredientCategories.Get())[0];
        gotten.Title = "Test 2";
        // Execute
        controller.PutIngredientCategory(gotten);
        IngredientCategory updated = ingredientCategories.GetById((int)gotten.IngredientCategoryId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public async void DeleteIngredientCategory_Removes_IngredientCategory_From_Context()
    {
        IngredientCategoryDto gotten = mapper.Map<List<IngredientCategoryDto>>(ingredientCategories.Get())[0];
        // Execute
        controller.DeleteIngredientCategory(gotten);
        IngredientCategory deleted = ingredientCategories.GetById((int)gotten.IngredientCategoryId);
        Assert.Null(deleted);
    }
}
