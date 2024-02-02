using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReceiptController : ControllerBase
{
    private readonly IRepository<Receipt> receipts;
    private readonly IMapper mapper;

    public ReceiptController(IRepository<Receipt> _receipts, IMapper _mapper)
    {
        receipts = _receipts;
        mapper = _mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult GetReceipts()
    {
        var result = receipts.Get();
        return Ok(mapper.Map<List<ReceiptDto>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PostReceipt(ReceiptDto receipt)
    {
        receipt.DateFulfilled = DateOnly.FromDateTime(DateTime.Today);
        receipts.Insert(mapper.Map<Receipt>(receipt));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult PutReceipt(ReceiptDto receipt)
    {
        if (receipt.ReceiptId == null)
            return Ok();

        Receipt existing = receipts.GetById((int)receipt.ReceiptId);
        receipt.Update(existing);
        receipts.Update(existing);
        return Ok();
    }

    [HttpDelete]
    public IActionResult DeleteReceipt(ReceiptDto receipt)
    {
        if (receipt.ReceiptId != null)
            receipts.Delete((int)receipt.ReceiptId);
        return Ok();
    }
}
