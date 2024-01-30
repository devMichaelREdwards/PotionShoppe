using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api")]
public class AuthController : ControllerBase
{
    private readonly IRepository<Customer> customers;
    private readonly IMapper mapper;
    private readonly IAuthService authService;

    public AuthController(
        IRepository<Customer> _customers,
        IMapper _mapper,
        IAuthService _authService
    )
    {
        customers = _customers;
        mapper = _mapper;
        authService = _authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(UserRegistrationDto userRegistration)
    {
        // If Customer
        await authService.RegisterCustomer(userRegistration);
        return Ok();
    }

    [HttpPost("login")]
    public IActionResult Login(UserLoginDto userLogin)
    {
        return Ok();
    }

    [HttpPost("employee/register")]
    public IActionResult EmployeeRegister(UserRegistrationDto userRegistration)
    {
        return Ok();
    }

    [HttpPost("employee/login")]
    public IActionResult EmployeeLogin(UserLoginDto userLogin)
    {
        return Ok();
    }
}
