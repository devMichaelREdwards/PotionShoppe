using System.Security.Claims;
using Api.Classes;
using Api.Models;

public interface IAuthService
{
    Task<bool> RegisterCustomer(CustomerRegistrationDto user);
    Task<bool> RegisterEmployee(EmployeeRegistrationDto user);
    Task<bool> RegisterOwner(EmployeeRegistrationDto user);
    Task<bool> Login(UserLoginDto user);
    Jwt GenerateJwt(string userName, string role);
    string UpdateRefreshToken(UserLoginDto user);
    CustomerUser GetCustomerUser(ClaimsPrincipal userClaims);
    string GetEmployeePositionString(string userName);
    bool CheckEmployeeRefreshToken(string userName, string refreshToken);
}
