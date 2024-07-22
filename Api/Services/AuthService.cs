using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
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
    private readonly IListingRepository<Customer> customers;
    private readonly IRepository<CustomerStatus> customerStatuses;
    private readonly IRepository<EmployeeAccount> employeeAccounts;
    private readonly IRepository<EmployeePosition> employeePositions;
    private readonly IListingRepository<Employee> employees;
    private readonly IConfiguration config;
    private readonly IMapper mapper;

    public AuthService(
        UserManager<AuthUser> _userManager,
        IRepository<CustomerAccount> _customerAccounts,
        IListingRepository<Customer> _customers,
        IRepository<CustomerStatus> _customerStatuses,
        IListingRepository<Employee> _employees,
        IRepository<EmployeeAccount> _employeeAccounts,
        IRepository<EmployeePosition> _employeePositions,
        IConfiguration _config,
        IMapper _mapper
    )
    {
        userManager = _userManager;
        customerAccounts = _customerAccounts;
        customers = _customers;
        customerStatuses = _customerStatuses;
        employees = _employees;
        employeeAccounts = _employeeAccounts;
        employeePositions = _employeePositions;
        config = _config;
        mapper = _mapper;
    }

    #region Access Control
    public async Task<bool> Login(UserLoginDto user)
    {
        var userAccount = await userManager.FindByNameAsync(user.UserName);
        if (userAccount is null)
            return false;

        return await userManager.CheckPasswordAsync(userAccount, user.Password);
    }

    public void Logout(UserLogoutDto user)
    {
        ClearRefreshToken(user);
    }

    public Jwt GenerateJwt(string userName, string role)
    {
        IEnumerable<Claim>? claims = GetEmployeeClaims(userName, role);
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
        Jwt token = new()
        {
            Success = tokenString != null,
            Token = tokenString ?? "",
            UserName = userName,
            Roles = GetEmployeeRoles(userName)
        };
        return token;
    }

    public string UpdateRefreshToken(UserLoginDto user)
    {
        DateTime expire = DateTime.Now.AddMinutes(1440);
        SecurityToken refreshToken = new JwtSecurityToken(
            expires: expire,
            issuer: config.GetSection("Jwt:Issuer").Value,
            audience: config.GetSection("Jwt:Audience").Value
        )
        {
        };
        string refreshString = new JwtSecurityTokenHandler().WriteToken(refreshToken);
        (employeeAccounts as EmployeeAccountRepository)!.UpdateRefreshToken(user.UserName, refreshString, DateOnly.FromDateTime(expire));
        return refreshString;
    }

    public void ClearRefreshToken(UserLogoutDto user)
    {
        (employeeAccounts as EmployeeAccountRepository)!.ClearRefreshToken(user.UserName);
    }
    #endregion

    #region Customer

    public async Task<bool> RegisterCustomer(CustomerRegistrationDto userRegistration)
    {
        AuthUser? valid = await userManager.FindByNameAsync(userRegistration.UserName)!;
        bool succeeded = valid != null;
        if (!succeeded) // If the User does not currently exist, create it
        {
            var authUser = new AuthUser()
            {
                UserName = userRegistration.UserName,
                Email = userRegistration.Email,
            };
            var result = await userManager.CreateAsync(authUser, userRegistration.Password);
            succeeded = result.Succeeded;
        }


        if (succeeded) // If the customer exists or was created, add the Customer role and create a Customer entity
        {
            valid = await userManager.FindByNameAsync(userRegistration.UserName)!;
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
                new() { UserName = valid?.UserName, Email = valid?.Email, CustomerId = createdCustomer.CustomerId };

            customerAccounts.Insert(newCustomerAccount);
        }

        return true;
    }

    public CustomerUser GetCustomerUser(ClaimsPrincipal userClaims)
    {
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

    #endregion

    #region Employee

    public async Task<bool> RegisterEmployee(EmployeeRegistrationDto userRegistration)
    {
        AuthUser? valid = await userManager.FindByNameAsync(userRegistration.UserName)!;
        bool succeeded = valid != null;
        if (!succeeded) // If the User does not currently exist, create it
        {
            var authUser = new AuthUser()
            {
                UserName = userRegistration.UserName,
                Email = userRegistration.Email,
            };
            var result = await userManager.CreateAsync(authUser, userRegistration.Password);
            succeeded = result.Succeeded;
        }

        if (succeeded) // If the customer exists or was created, add the Customer role and create a Customer entity
        {
            valid = await userManager.FindByNameAsync(userRegistration.UserName)!;
            await userManager.AddToRoleAsync(valid!, "Employee");
            bool employeeExists = (employeeAccounts as EmployeeAccountRepository)!.EmployeeExists(
                valid!.UserName!
            );

            if (employeeExists)
                return false;

            EmployeePosition position = (employeePositions as EmployeePositionRepository)!.GetFirstByPosition("Employee");

            Employee newEmployee =
                new()
                {
                    FirstName = userRegistration.FirstName,
                    LastName = userRegistration.LastName,
                    EmployeeStatusId = userRegistration.EmployeeStatusId,
                    EmployeePositionId = position.EmployeePositionId
                };

            Employee createdEmployee = employees.Insert(newEmployee);

            EmployeeAccount newEmployeeAccount =
                new() { UserName = valid?.UserName, EmployeeId = createdEmployee.EmployeeId };

            employeeAccounts.Insert(newEmployeeAccount);
        }

        return true;
    }

    public async Task<bool> RegisterOwner(EmployeeRegistrationDto userRegistration)
    {
        AuthUser? valid = await userManager.FindByNameAsync(userRegistration.UserName)!;
        bool succeeded = valid != null;
        if (!succeeded) // If the User does not currently exist, create it
        {
            var authUser = new AuthUser()
            {
                UserName = userRegistration.UserName,
                Email = userRegistration.Email,
            };
            var result = await userManager.CreateAsync(authUser, userRegistration.Password);
            succeeded = result.Succeeded;
        }

        if (succeeded) // If the owner exists or was created, add the Customer role and create a Customer entity
        {
            valid = await userManager.FindByNameAsync(userRegistration.UserName)!;
            await userManager.AddToRoleAsync(valid!, "Owner");
            await userManager.AddToRoleAsync(valid!, "Employee");
            bool employeeExists = (employeeAccounts as EmployeeAccountRepository)!.EmployeeExists(
                valid!.UserName!
            );

            if (employeeExists)
                return false;

            EmployeePosition position = (employeePositions as EmployeePositionRepository)!.GetFirstByPosition("Owner");

            Employee newEmployee =
                new()
                {
                    FirstName = userRegistration.FirstName,
                    LastName = userRegistration.LastName,
                    EmployeeStatusId = userRegistration.EmployeeStatusId,
                    EmployeePositionId = position.EmployeePositionId
                };

            Employee createdEmployee = employees.Insert(newEmployee);

            EmployeeAccount newEmployeeAccount =
                new() { UserName = valid?.UserName, EmployeeId = createdEmployee.EmployeeId };

            employeeAccounts.Insert(newEmployeeAccount);
        }

        return true;
    }

    private IEnumerable<Claim>? GetEmployeeClaims(string userName, string role)
    {
        if (role == "Owner") return [
            new(ClaimTypes.Email, userName),
            new(ClaimTypes.Role, role),
            new(ClaimTypes.Role, "Employee")
        ];

        if (role == "Employee") return [
            new(ClaimTypes.Email, userName),
            new(ClaimTypes.Role, role)
        ];

        return null;
    }

    public string GetEmployeePositionString(string userName)
    {
        EmployeeAccount account = (employeeAccounts as EmployeeAccountRepository)!.GetByUserName(userName);
        return (employees as EmployeeRepository)!.GetEmployeePositionByEmployeeId((int)account.EmployeeId!).Title!;
    }

    private string[] GetEmployeeRoles(string userName)
    {
        // Think of better way to do this. Possible to do something with ASP.Net roles?
        string position = GetEmployeePositionString(userName);
        if (position == "Owner") return ["Employee", "Owner"];
        if (position == "Employee") return ["Employee"];
        return [];

    }

    public bool CheckEmployeeRefreshToken(string userName, string refreshToken)
    {
        RefreshToken? token = (employeeAccounts as EmployeeAccountRepository)!.GetRefreshTokenForUser(userName);
        if (token is null || token.Token != refreshToken)
        {
            return false;
        }

        if (DateOnly.FromDateTime(DateTime.UtcNow).CompareTo(token.Expire) > 0)
        {
            (employeeAccounts as EmployeeAccountRepository)!.UpdateRefreshToken(userName, null, null);
            return false;
        }

        return true;
    }

    #endregion
}
