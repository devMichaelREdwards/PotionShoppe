using Api.Classes;
using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/user")]
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
    public async Task<IActionResult> Register(CustomerRegistrationDto userRegistration)
    {
        bool success = await authService.RegisterCustomer(userRegistration);
        return success ? Ok(success) : BadRequest("Something went wrong");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(UserLoginDto userLogin)
    {
        var result = await authService.LoginCustomer(userLogin);
        if (result)
        {
            Jwt token = authService.GenerateJwt(userLogin, "Customer");
            return Ok(token);
        }
        return BadRequest("Login Failed");
    }

    [HttpPost("employee/register")]
    public async Task<IActionResult> EmployeeRegister(EmployeeRegistrationDto userRegistration)
    {
        return Ok();
    }

    [HttpPost("employee/login")]
    public async Task<IActionResult> EmployeeLogin(UserLoginDto userLogin)
    {
        return Ok();
    }
}
