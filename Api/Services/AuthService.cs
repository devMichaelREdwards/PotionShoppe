using System.Diagnostics.Eventing.Reader;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks.Sources;
using Api.Classes;
using Api.Data;
using Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Api.Service;

public class AuthService : IAuthService
{
    private readonly UserManager<AuthUser> userManager;
    private readonly IRepository<CustomerAccount> customerAccounts;
    private readonly IRepository<Customer> customers;
    private readonly IRepository<CustomerStatus> customerStatuses;
    private readonly IConfiguration config;
    private readonly IMapper mapper;

    public AuthService(
        UserManager<AuthUser> _userManager,
        IRepository<CustomerAccount> _customerAccounts,
        IRepository<Customer> _customers,
        IRepository<CustomerStatus> _customerStatuses,
        IConfiguration _config,
        IMapper _mapper
    )
    {
        userManager = _userManager;
        customerAccounts = _customerAccounts;
        customers = _customers;
        customerStatuses = _customerStatuses;
        config = _config;
        mapper = _mapper;
    }

    #region Customer

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


        if (succeeded) // If the customer exists or was created, add the Customer role and create a Customer entity
        {
            valid = await userManager.FindByNameAsync(userRegistration.Username)!;
            await userManager.AddToRoleAsync(valid!, "Customer");
            bool customerExists = (customerAccounts as CustomerAccountRepository)!.CustomerExists(
                valid!.UserName!
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

            CustomerAccount newCustomerAccount =
                new() { UserName = valid?.UserName, CustomerId = createdCustomer.CustomerId };

            customerAccounts.Insert(newCustomerAccount);
        }

        return true;
    }

    public async Task<bool> LoginCustomer(UserLoginDto user)
    {
        var userAccount = await userManager.FindByNameAsync(user.Username);
        if (userAccount is null)
            return false;

        return await userManager.CheckPasswordAsync(userAccount, user.Password);
    }

    #endregion

    #region Employee

    public Task<bool> RegisterEmployee(CustomerRegistrationDto user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> RegisterOwner(CustomerRegistrationDto user)
    {
        throw new NotImplementedException();
    }
    #endregion

    public Jwt GenerateJwt(UserLoginDto user, string role)
    {
        IEnumerable<Claim> claims =
        [
            new(ClaimTypes.Email, user.Username),
            new(ClaimTypes.Role, role)
        ];
        SymmetricSecurityKey securityKey = new(
            Encoding.ASCII.GetBytes(config.GetSection("Jwt:SecretKey").Value!)
        );
        SigningCredentials signingCred = new(
            securityKey,
            SecurityAlgorithms.HmacSha512Signature
        );
        SecurityToken securityToken = new JwtSecurityToken(
            claims: claims,
            expires: DateTime.Now.AddMinutes(60),
            issuer: config.GetSection("Jwt:Issuer").Value,
            audience: config.GetSection("Jwt:Audience").Value,
            signingCredentials: signingCred
        )
        {
            };
        string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);

        Jwt token = new() { Token = tokenString };

        return token;
    }

    public CustomerUser GetCustomerUser(ClaimsPrincipal userClaims) {
        string userName = userClaims.FindFirst(ClaimTypes.Email)!.Value;

        CustomerAccount account = (customerAccounts as CustomerAccountRepository)!.GetByUserName(
            userName
        );

        if (account?.CustomerId is null)
            return null;

        int customerId = (int)account.CustomerId;
        Customer customerData = customers.GetById(customerId);

        CustomerUser user = new CustomerUser()
        {
            UserName = userName,
            Customer = mapper.Map<CustomerDto>(customerData)
        };

        return user;
    }
}
