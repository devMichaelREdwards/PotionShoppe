using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class OrderStatusControllerTest
{
    TestOrderStatusRepository employeeStatuses;
    IMapper mapper;
    OrderStatusController controller;

    public OrderStatusControllerTest()
    {
        // Setup
        employeeStatuses = new TestOrderStatusRepository();
        mapper = MapperFaker.MockMapper();
        controller = new OrderStatusController(employeeStatuses, mapper);
    }

    [Fact]
    public async void GetOrderStatus_Returns_Correct_OrderStatus_Data()
    {
        // Execute
        IActionResult result = controller.GetOrderStatuses();
        OkObjectResult ok = result as OkObjectResult;
        List<OrderStatusDto> statusResult = ok.Value as List<OrderStatusDto>;
        // Assert
        Assert.Equal(DataFaker.FakeOrderStatuses().Count, statusResult.Count);
    }

    [Fact]
    public async void PostOrderStatus_Returns_OrderStatus_Data_With_Given_Id()
    {
        int testId = 1000;
        OrderStatusDto testStatus = new() { OrderStatusId = testId, Title = "Test" };
        // Execute
        controller.PostOrderStatus(testStatus);
        OrderStatus newStatus = employeeStatuses.GetById(testId);
        // Assert
        Assert.True(testStatus.Equals(newStatus));
    }

    [Fact]
    public async void PutOrderStatus_Returns_OrderStatus_With_Updated_Data()
    {
        OrderStatusDto gotten = mapper.Map<List<OrderStatusDto>>(employeeStatuses.Get())[0];
        gotten.Title = "Test 2";
        // Execute
        controller.PutOrderStatus(gotten);
        OrderStatus updated = employeeStatuses.GetById((int)gotten.OrderStatusId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public async void DeleteOrderStatus_Removes_OrderStatus_From_Context()
    {
        OrderStatusDto gotten = mapper.Map<List<OrderStatusDto>>(employeeStatuses.Get())[0];
        // Execute
        controller.DeleteOrderStatus(gotten);
        OrderStatus deleted = employeeStatuses.GetById((int)gotten.OrderStatusId);
        Assert.Null(deleted);
    }
}
