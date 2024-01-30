using Api.Models;

public interface IAuthService
{
    Task<bool> RegisterCustomer(CustomerRegistrationDto user);
    Task<bool> RegisterEmployee(CustomerRegistrationDto user);
    Task<bool> RegisterOwner(CustomerRegistrationDto user);
}
