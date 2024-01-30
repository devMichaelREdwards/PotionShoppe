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
    private readonly IRepository<CustomerAccount> customerAccounts;
    private readonly IRepository<Customer> customers;
    private readonly IRepository<CustomerStatus> customerStatuses;

    public AuthService(
        UserManager<AuthUser> _userManager,
        IRepository<CustomerAccount> _customerAccounts,
        IRepository<Customer> _customers,
        IRepository<CustomerStatus> _customerStatuses
    )
    {
        userManager = _userManager;
        customerAccounts = _customerAccounts;
        customers = _customers;
        customerStatuses = _customerStatuses;
    }

    public async Task<bool> RegisterCustomer(CustomerRegistrationDto userRegistration)
    {
        AuthUser? valid = await userManager.FindByNameAsync(userRegistration.Username)!;
        bool succeeded = valid != null;
        if (!succeeded) // If the Customer does not currently exist, create it
        {
            var authUser = new AuthUser()
            {
                UserName = userRegistration.Username,
                Email = userRegistration.Email,
            };
            var result = await userManager.CreateAsync(authUser, userRegistration.Password);
            succeeded = result.Succeeded;
        }

        await userManager.AddToRoleAsync(valid!, "Customer");

        if (succeeded) // If the customer exists(including after creation) and does not have a customer linked
        {
            valid = await userManager.FindByNameAsync(userRegistration.Username)!;
            bool customerExists = (customerAccounts as CustomerAccountRepository)!.CustomerExists(
                valid!.Id
            );

            if (customerExists)
                return false;

            CustomerStatus activeStatus = (
                customerStatuses as CustomerStatusRepository
            )!.GetFirstByStatus("ACTIVE");

            Customer newCustomer =
                new()
                {
                    FirstName = userRegistration.FirstName,
                    LastName = userRegistration.LastName,
                    CustomerStatusId = activeStatus.CustomerStatusId
                };

            Customer createdCustomer = customers.Insert(newCustomer);

            CustomerAccount newCustomerAccount = new CustomerAccount()
            {
                UserId = valid?.Id,
                CustomerId = createdCustomer.CustomerId
            };

            customerAccounts.Insert(newCustomerAccount);
        }

        return true;
    }

    public Task<bool> RegisterEmployee(CustomerRegistrationDto user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegisterOwner(CustomerRegistrationDto user)
    {
        throw new NotImplementedException();
    }
}
