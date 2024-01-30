using System.Diagnostics.Eventing.Reader;
using System.Threading.Tasks.Sources;
using Api.Classes;
using Api.Data;
using Api.Models;
using Microsoft.AspNetCore.Identity;

namespace Api.Service;

public class AuthService : IAuthService
{
    private readonly UserManager<AuthUser> userManager;
    private readonly IRepository<Customer> customers;

    public AuthService(UserManager<AuthUser> _userManager, IRepository<Customer> _customers)
    {
        userManager = _userManager;
        customers = _customers;
    }

    public async Task<bool> RegisterCustomer(UserRegistrationDto user)
    {
        AuthUser? valid = await userManager.FindByNameAsync(user.Username)!;
        if (valid == null)
        {
            var authUser = new AuthUser() { UserName = user.Username, Email = user.Email, };
            var result = await userManager.CreateAsync(authUser, user.Password);
            // Set valid to new user
        }

        if (true) // ASP.Net account has no customer attached
        {
            // Create a customer and attach it to the ASP.Net account
        }

        return true;
    }

    public Task<bool> RegisterEmployee(UserRegistrationDto user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegisterOwner(UserRegistrationDto user)
    {
        throw new NotImplementedException();
    }
}
