using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class OrderPotionControllerTest
{
    TestOrderPotionRepository potions;
    IMapper mapper;
    OrderPotionController controller;

    public OrderPotionControllerTest()
    {
        // Setup
        potions = new TestOrderPotionRepository();
        mapper = MapperFaker.MockMapper();
        controller = new OrderPotionController(potions, mapper);
    }

    [Fact]
    public void GetOrderPotion_Returns_Correct_OrderPotion_Data()
    {
        // Execute
        IActionResult result = controller.GetOrderPotions();
        OkObjectResult ok = result as OkObjectResult;
        List<OrderPotionDto> Result = ok.Value as List<OrderPotionDto>;
        // Assert
        Assert.Equal(DataFaker.FakeOrderPotions().Count, Result.Count);
    }

    [Fact]
    public void PostOrderPotion_Returns_OrderPotion_Data_With_Given_Id()
    {
        int testId = 1000;
        OrderPotionDto test = new() { OrderPotionId = testId, PotionId = 2 };
        // Execute
        controller.PostOrderPotion(test);
        OrderPotion newOrderPotion = potions.GetById(testId);
        // Assert
        Assert.True(test.Equals(newOrderPotion));
    }

    [Fact]
    public void PutOrderPotion_Returns_OrderPotion_With_Updated_Data()
    {
        OrderPotionDto gotten = mapper.Map<List<OrderPotionDto>>(potions.Get())[0];
        gotten.PotionId = 2;
        // Execute
        controller.PutOrderPotion(gotten);
        OrderPotion updated = potions.GetById((int)gotten.OrderPotionId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public void DeleteOrderPotion_Removes_OrderPotion_From_Context()
    {
        OrderPotionDto gotten = mapper.Map<List<OrderPotionDto>>(potions.Get())[0];
        // Execute
        controller.DeleteOrderPotion(gotten);
        OrderPotion deleted = potions.GetById((int)gotten.OrderPotionId);
        Assert.Null(deleted);
    }
}
