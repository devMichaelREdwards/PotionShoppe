using Api.Classes;
using Api.Data;
using Api.Models;
using Api.Service;
using Microsoft.AspNetCore.Identity;

namespace Api.Setup;

public static class SeedRoles
{
    public static async Task CreateUserRoles(IServiceProvider serviceProvider)
    {
        IRepository<EmployeePosition> repository = serviceProvider.GetRequiredService<
            IRepository<EmployeePosition>
        >();
        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        if (!await roleManager.RoleExistsAsync("Customer"))
        {
            await roleManager.CreateAsync(new IdentityRole("Customer"));
        }

        IEnumerable<EmployeePosition> positions = repository.Get();
        foreach (EmployeePosition position in positions)
        {
            if (position.Title != null && !await roleManager.RoleExistsAsync(position.Title))
            {
                await roleManager.CreateAsync(new IdentityRole(position.Title));
            }
        }
    }

    public static async Task AssignDefaultRoles(IServiceProvider serviceProvider) // This is only ran in development builds
    {
        var authService = serviceProvider.GetRequiredService<IAuthService>();
        IRepository<EmployeeStatus> repository = serviceProvider.GetRequiredService<
            IRepository<EmployeeStatus>
        >();

        EmployeeStatus status = (repository as EmployeeStatusRepository).GetFirstByStatus("ACTIVE");
        string ownerUsername = "potionShoppe";
        string ownerEmail = "potionShoppe@potionShoppe.com";
        EmployeeRegistrationDto ownerRegister = new EmployeeRegistrationDto()
        {
            Username = "potionShoppe",
            Password = "potionPassword1!",
            FirstName = "Potion",
            LastName = "Shoppe",
            Email = "owner@potionshoppe.com",
            EmployeeStatusId = status.EmployeeStatusId
        };
        bool success = await authService.RegisterOwner(ownerRegister);
    }
}
