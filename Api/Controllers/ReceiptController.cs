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
    private readonly IListingRepository<Receipt> _receipts;
    private readonly IMapper _mapper;

    public ReceiptController(IListingRepository<Receipt> receipts, IMapper mapper)
    {
        _receipts = receipts;
        _mapper = mapper;
    }

    [HttpGet]
    [Authorize(Roles = "Owner")]
    public IActionResult GetReceipts()
    {
        var result = _receipts.Get();
        return Ok(_mapper.Map<List<ReceiptDto>>(result));
    }

    [HttpGet("listing")]
    [Authorize(Roles = "Employee")]
    public IActionResult GetReceiptsListing()
    {
        Pagination? page = Pagination.BuildFilter(Request.Query);
        var result = _receipts.GetListing(null, page);
        return Ok(_mapper.Map<List<ReceiptListing>>(result));
    }

    [HttpPost]
    [Authorize(Roles = "Employee")]
    public IActionResult PostReceipt(ReceiptDto receipt)
    {
        receipt.DateFulfilled = DateOnly.FromDateTime(DateTime.Today);
        _receipts.Insert(_mapper.Map<Receipt>(receipt));
        return Ok();
    }

    [HttpPut]
    [Authorize(Roles = "Owner")]
    public IActionResult PutReceipt(ReceiptDto receipt)
    {
        if (receipt.ReceiptId == null)
            return Ok();

        Receipt existing = _receipts.GetById((int)receipt.ReceiptId);
        receipt.Update(existing);
        _receipts.Update(existing);
        return Ok();
    }

    [HttpDelete]
    [Authorize(Roles = "Owner")]
    public IActionResult DeleteReceipt(ReceiptDto receipt)
    {
        if (receipt.ReceiptId != null)
            _receipts.Delete((int)receipt.ReceiptId);
        return Ok();
    }
}
