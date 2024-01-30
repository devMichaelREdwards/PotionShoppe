using Api.Models;

public interface IAuthService
{
    Task<bool> RegisterCustomer(UserRegistrationDto user);
    Task<bool> RegisterEmployee(UserRegistrationDto user);
    Task<bool> RegisterOwner(UserRegistrationDto user);
}
