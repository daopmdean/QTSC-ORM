using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QTSC_ORM.Data.Entities;

namespace QTSC_ORM.Seedings
{
    public class SeedingData
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            if (await userManager.Users.AnyAsync())
                return;

            var userData = await File.ReadAllTextAsync("Seedings/generated_users.json");
            var users = JsonSerializer.Deserialize<List<AppUser>>(userData);

            if (users == null)
                return;

            var roles = new List<AppRole>
            {
                new AppRole{ Name = "Admin"},
                new AppRole{ Name = "User"},
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            foreach (var user in users)
            {
                user.UserName = user.UserName.ToLower();

                await userManager.CreateAsync(user, "password");
                await userManager.AddToRoleAsync(user, "User");
            }

            var admin = new AppUser
            {
                UserName = "admin"
            };

            admin.SecurityStamp = Guid.NewGuid().ToString();

            await userManager.CreateAsync(admin, "password");
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
