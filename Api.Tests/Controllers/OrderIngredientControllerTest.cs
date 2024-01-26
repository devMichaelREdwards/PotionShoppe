using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class OrderIngredientControllerTest
{
    TestOrderIngredientRepository potions;
    IMapper mapper;
    OrderIngredientController controller;

    public OrderIngredientControllerTest()
    {
        // Setup
        potions = new TestOrderIngredientRepository();
        mapper = MapperFaker.MockMapper();
        controller = new OrderIngredientController(potions, mapper);
    }

    [Fact]
    public void GetOrderIngredient_Returns_Correct_OrderIngredient_Data()
    {
        // Execute
        IActionResult result = controller.GetOrderIngredients();
        OkObjectResult ok = result as OkObjectResult;
        List<OrderIngredientDto> Result = ok.Value as List<OrderIngredientDto>;
        // Assert
        Assert.Equal(DataFaker.FakeOrderIngredients().Count, Result.Count);
    }

    [Fact]
    public void PostOrderIngredient_Returns_OrderIngredient_Data_With_Given_Id()
    {
        int testId = 1000;
        OrderIngredientDto test = new() { OrderIngredientId = testId, IngredientId = 2 };
        // Execute
        controller.PostOrderIngredient(test);
        OrderIngredient newOrderIngredient = potions.GetById(testId);
        // Assert
        Assert.True(test.Equals(newOrderIngredient));
    }

    [Fact]
    public void PutOrderIngredient_Returns_OrderIngredient_With_Updated_Data()
    {
        OrderIngredientDto gotten = mapper.Map<List<OrderIngredientDto>>(potions.Get())[0];
        gotten.IngredientId = 2;
        // Execute
        controller.PutOrderIngredient(gotten);
        OrderIngredient updated = potions.GetById((int)gotten.OrderIngredientId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public void DeleteOrderIngredient_Removes_OrderIngredient_From_Context()
    {
        OrderIngredientDto gotten = mapper.Map<List<OrderIngredientDto>>(potions.Get())[0];
        // Execute
        controller.DeleteOrderIngredient(gotten);
        OrderIngredient deleted = potions.GetById((int)gotten.OrderIngredientId);
        Assert.Null(deleted);
    }
}
