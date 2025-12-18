using MatriculaEscolarIPTC.Models;
using Microsoft.AspNetCore.Identity;

namespace MatriculaEscolarIPTC.Data;

public static class SeedData
{
    public static readonly string[] Roles = new[] { "Admin", "Secretaria", "Profesor" };

    public static async Task SeedAsync(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager)
    {
        foreach (var r in Roles)
        {
            if (!await roleManager.RoleExistsAsync(r))
                await roleManager.CreateAsync(new IdentityRole(r));
        }

        // Admin default (cámbialo en producción)
        var adminEmail = "admin@iptc.local";
        var admin = await userManager.FindByEmailAsync(adminEmail);
        if (admin is null)
        {
            admin = new AppUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                NombreCompleto = "Administrador"
            };

            var result = await userManager.CreateAsync(admin, "Admin123!");
            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
