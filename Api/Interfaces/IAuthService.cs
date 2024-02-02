using System.Security.Claims;
using Api.Classes;
using Api.Models;

public interface IAuthService
{
    Task<bool> RegisterCustomer(CustomerRegistrationDto user);
    Task<bool> RegisterEmployee(EmployeeRegistrationDto user);
    Task<bool> RegisterOwner(EmployeeRegistrationDto user);
    Task<bool> Login(UserLoginDto user);
    Jwt GenerateJwt(UserLoginDto user, string role);
    CustomerUser GetCustomerUser(ClaimsPrincipal userClaims);
    string GetEmployeePositionString(string userName);
}
