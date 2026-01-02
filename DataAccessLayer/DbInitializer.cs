using Domain.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AccessLayer;

public static class DbInitializer
{
    public const string AdminRole = "admin";
    public const string UserRole = "user";

    public static async Task InitializeAsync(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        // Создаём роли, если их нет
        string[] roleNames = { AdminRole, UserRole };
        foreach (var roleName in roleNames)
        {
            if (!await roleManager.RoleExistsAsync(roleName))
            {
                await roleManager.CreateAsync(new Role { Name = roleName });
            }
        }

        // Создаём админа
        var admin = new PersonName { Lastname = "Админов", Firstname = "Админ", Middlename = "Админович" };
        var user = new PersonName { Lastname = "Лазарев", Firstname = "Дмитрий", Middlename = "Иванович" };

        var adminEmail = "admin@example.com";
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        if (adminUser == null)
        {
            adminUser = new User
            {
                UserName = adminEmail,
                Email = adminEmail,
                WorkerName = admin,
            };
            await userManager.CreateAsync(adminUser, "Admin123!");
            await userManager.AddToRoleAsync(adminUser, AdminRole);
        }

        // Создаём обычного пользователя
        var userEmail = "user@example.com";
        var standardUser = await userManager.FindByEmailAsync(userEmail);
        if (standardUser == null)
        {
            standardUser = new User
            {
                UserName = userEmail,
                Email = userEmail,
                WorkerName = user,
            };
            await userManager.CreateAsync(standardUser, "User123!");
            await userManager.AddToRoleAsync(standardUser, UserRole);
        }
    }
}