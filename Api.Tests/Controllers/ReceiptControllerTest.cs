using Api.Controllers;
using Api.Models;
using AutoMapper;
using Faker;
using Microsoft.AspNetCore.Mvc;

namespace Api.Tests;

public class ReceiptControllerTest
{
    TestReceiptRepository potions;
    IMapper mapper;
    ReceiptController controller;

    public ReceiptControllerTest()
    {
        // Setup
        potions = new TestReceiptRepository();
        mapper = MapperFaker.MockMapper();
        controller = new ReceiptController(potions, mapper);
    }

    [Fact]
    public void GetReceipt_Returns_Correct_Receipt_Data()
    {
        // Execute
        IActionResult result = controller.GetReceipts();
        OkObjectResult ok = result as OkObjectResult;
        List<ReceiptDto> Result = ok.Value as List<ReceiptDto>;
        // Assert
        Assert.Equal(DataFaker.FakeReceipts().Count, Result.Count);
    }

    [Fact]
    public void PostReceipt_Returns_Receipt_Data_With_Given_Id()
    {
        int testId = 1000;
        ReceiptDto test =
            new()
            {
                ReceiptId = testId
            };
        // Execute
        controller.PostReceipt(test);
        Receipt newReceipt = potions.GetById(testId);
        // Assert
        Assert.True(test.Equals(newReceipt));
    }

    [Fact]
    public void PutReceipt_Returns_Receipt_With_Updated_Data()
    {
        ReceiptDto gotten = mapper.Map<List<ReceiptDto>>(potions.Get())[0];
        gotten.DateFulfilled = DateOnly.FromDateTime(DateTime.Today);
        // Execute
        controller.PutReceipt(gotten);
        Receipt updated = potions.GetById((int)gotten.ReceiptId);
        // Assert
        Assert.True(gotten.Equals(updated));
    }

    [Fact]
    public void DeleteReceipt_Removes_Receipt_From_Context()
    {
        ReceiptDto gotten = mapper.Map<List<ReceiptDto>>(potions.Get())[0];
        // Execute
        controller.DeleteReceipt(gotten);
        Receipt deleted = potions.GetById((int)gotten.ReceiptId);
        Assert.Null(deleted);
    }
}
