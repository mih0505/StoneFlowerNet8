using System;
using System.Linq;
using System.Threading;
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

        // Сиды организаций и подразделений
        var db = serviceProvider.GetRequiredService<StoneFlowersDbContext>();

        if (!db.Organizations.Any(o => o.Name == "(Д) Каменный цветок"))
        {
            var orgD = new Organization { Id = Guid.NewGuid(), Name = "(Д) Каменный цветок" };
            orgD.Departments.Add(new Department { Id = Guid.NewGuid(), Name = "Гоголя", Code = "Д-Гоголя", Address = new Address { House = "-" }, PhoneNumbers = new PhoneNumbers { PhoneNumber = "-" } });
            orgD.Departments.Add(new Department { Id = Guid.NewGuid(), Name = "Свободы", Code = "Д-Свободы", Address = new Address { House = "-" }, PhoneNumbers = new PhoneNumbers { PhoneNumber = "-" } });
            db.Organizations.Add(orgD);
        }

        if (!db.Organizations.Any(o => o.Name == "(Ю) Каменный цветок"))
        {
            var orgY = new Organization { Id = Guid.NewGuid(), Name = "(Ю) Каменный цветок" };
            orgY.Departments.Add(new Department { Id = Guid.NewGuid(), Name = "Ленина", Code = "Ю-Ленина", Address = new Address { House = "-" }, PhoneNumbers = new PhoneNumbers { PhoneNumber = "-" } });
            orgY.Departments.Add(new Department { Id = Guid.NewGuid(), Name = "Дом Быта", Code = "Ю-ДомБыта", Address = new Address { House = "-" }, PhoneNumbers = new PhoneNumbers { PhoneNumber = "-" } });
            db.Organizations.Add(orgY);
        }

        await db.SaveChangesAsync(CancellationToken.None);
    }
}