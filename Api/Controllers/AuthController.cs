using Api.Classes;
using Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/user")]
public class AuthController : ControllerBase
{
    private readonly IAuthService authService;

    public AuthController(IAuthService _authService)
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
    public async Task<IActionResult> CustomerLogin(UserLoginDto userLogin)
    {
        var result = await authService.Login(userLogin);
        if (result)
        {
            Jwt token = authService.GenerateJwt(userLogin.UserName, "Customer");
            return Ok(token);
        }
        return BadRequest("Login Failed");
    }

    [HttpPost("employee/register")]
    [Authorize(Roles = "Owner")]
    public async Task<IActionResult> EmployeeRegister(EmployeeRegistrationDto userRegistration)
    {
        bool success = await authService.RegisterEmployee(userRegistration);
        return success ? Ok(success) : BadRequest("Something went wrong");
    }

    [HttpPost("owner/register")]
    [Authorize(Roles = "Owner")]
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
            string position = authService.GetEmployeePositionString(userLogin.UserName);
            Jwt token = authService.GenerateJwt(userLogin.UserName, position);
            string refresh = authService.UpdateRefreshToken(userLogin);
            Response.Cookies.Append(
                "potionShoppeUserName",
                userLogin.UserName,
                Cookie.GetOptions()
            );
            Response.Cookies.Append("potionShoppe", refresh, Cookie.GetOptions());
            return Ok(token);
        }

        return BadRequest("Login Failed");
    }

    [HttpPost("employee/logout")]
    public async Task<IActionResult> EmployeeLogout(UserLogoutDto userLogout)
    {
        // Clear user JWT
        authService.ClearRefreshToken(userLogout);
        // Delete cookie from user
        Response.Cookies.Delete("potionShoppeUserName");
        Response.Cookies.Delete("potionShoppe");

        return Ok();
    }

    [HttpGet("employee/refresh")]
    public IActionResult EmployeeRefresh()
    {
        if (
            Request.Cookies["potionShoppeUserName"] == null
            || Request.Cookies["potionShoppe"] == null
        )
        {
            return Ok(false);
        }

        string userName = Request.Cookies["potionShoppeUserName"]!;
        string refreshToken = Request.Cookies["potionShoppe"]!;
        bool tokenIsValid = authService.CheckEmployeeRefreshToken(userName, refreshToken);
        if (tokenIsValid)
        {
            string position = authService.GetEmployeePositionString(userName);
            Jwt token = authService.GenerateJwt(userName, position);
            return Ok(token);
        }
        string message = "No Token Found";
        return Ok(message);
    }

    [HttpPost("employee/authenticate")]
    [Authorize(Roles = "Employee,Owner")]
    public IActionResult Authenticate()
    {
        bool authenticated = true;
        return Ok(authenticated);
    }
}
