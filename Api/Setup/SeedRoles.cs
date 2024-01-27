using Api.Classes;
using Api.Data;
using Api.Models;
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

    public static async Task AssignDefaultRoles(IServiceProvider serviceProvider)
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<AuthUser>>();

        string ownerUsername = "potionShoppe";
        string ownerEmail = "potionShoppe@potionShoppe.com";
        if (await userManager.FindByEmailAsync(ownerEmail) == null)
        {
            string ownerPassword = "potionPassword1!"; // This is a development thing. Remove this.
            var user = new AuthUser();
            user.UserName = ownerUsername;
            user.Email = ownerEmail;
            user.EmailConfirmed = true;

            await userManager.CreateAsync(user, ownerPassword);

            await userManager.AddToRoleAsync(user, "Owner");
        }
    }
}
