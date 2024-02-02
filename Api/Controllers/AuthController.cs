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
    private readonly IAuthService authService;

    public AuthController(
        IAuthService _authService
    )
    {
        authService = _authService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(CustomerRegistrationDto userRegistration)
    {
        bool success = await authService.RegisterCustomer(userRegistration);
        return success ? Ok(success) : BadRequest("Something went wrong");
    }

    [HttpPost("login")]
    public async Task<IActionResult> LoginCustomer(UserLoginDto userLogin)
    {
        var result = await authService.Login(userLogin);
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
        bool success = await authService.RegisterEmployee(userRegistration);
        return success ? Ok(success) : BadRequest("Something went wrong");
    }

    [HttpPost("owner/register")]
    public async Task<IActionResult> OwnerRegister(EmployeeRegistrationDto userRegistration)
    {
        bool success = await authService.RegisterOwner(userRegistration);
        return success ? Ok(success) : BadRequest("Something went wrong");
    }

    [HttpPost("employee/login")]
    public async Task<IActionResult> EmployeeLogin(UserLoginDto userLogin)
    {
        var result = await authService.Login(userLogin);
        if (result)
        {
            string position = authService.GetEmployeePositionString(userLogin.Username);
            Jwt token = authService.GenerateJwt(userLogin, position);
            return Ok(token);
        }
        return BadRequest("Login Failed");
    }
}
