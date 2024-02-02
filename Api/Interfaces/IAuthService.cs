using System.Security.Claims;
using Api.Classes;
using Api.Models;

public interface IAuthService
{
    Task<bool> RegisterCustomer(CustomerRegistrationDto user);
    Task<bool> LoginCustomer(UserLoginDto user);
    Task<bool> RegisterEmployee(CustomerRegistrationDto user);
    Task<bool> RegisterOwner(CustomerRegistrationDto user);
    Jwt GenerateJwt(UserLoginDto user, string role);
    CustomerUser GetCustomerUser(ClaimsPrincipal userClaims);
}
