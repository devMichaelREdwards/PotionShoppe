using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class OrderControllerTest
{
    TestOrderRepository potions;
    IMapper mapper;
    OrderController controller;

    public OrderControllerTest()
    {
        // Setup
        potions = new TestOrderRepository();
        mapper = MapperFaker.MockMapper();
        controller = new OrderController(potions, mapper);
    }

    [Fact]
    public void GetOrder_Returns_Correct_Order_Data()
    {
        // Execute
        IActionResult result = controller.GetOrders();
        OkObjectResult ok = result as OkObjectResult;
        List<OrderDto> Result = ok.Value as List<OrderDto>;
        // Assert
        Assert.Equal(DataFaker.FakeOrders().Count, Result.Count);
    }

    [Fact]
    public void PostOrder_Returns_Order_Data_With_Given_Id()
    {
        int testId = 1000;
        OrderDto test =
            new()
            {
                OrderId = testId,
                OrderStatusId = 2
            };
        // Execute
        controller.PostOrder(test);
        Order newOrder = potions.GetById(testId);
        // Assert
        Assert.True(test.Equals(newOrder));
    }

    [Fact]
    public void PutOrder_Returns_Order_With_Updated_Data()
    {
        OrderDto gotten = mapper.Map<List<OrderDto>>(potions.Get())[0];
        gotten.OrderStatusId = 2;
        // Execute
        controller.PutOrder(gotten);
        Order updated = potions.GetById((int)gotten.OrderId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public void DeleteOrder_Removes_Order_From_Context()
    {
        OrderDto gotten = mapper.Map<List<OrderDto>>(potions.Get())[0];
        // Execute
        controller.DeleteOrder(gotten);
        Order deleted = potions.GetById((int)gotten.OrderId);
        Assert.Null(deleted);
    }
}
