using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using QTSC_ORM.Data;
using QTSC_ORM.Data.Entities;
using QTSC_ORM.Data.Repositories.Interfaces;

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

        public static async Task SeedCustomers(DataContext context,
            ICustomerRepository customerRepository)
        {
            if (await context.Customers.AnyAsync())
                return;

            var customerData = await File.ReadAllTextAsync("Seedings/generated_customers.json");
            var customers = JsonSerializer.Deserialize<List<Customer>>(customerData);

            if (customers == null)
                return;

            foreach (var customer in customers)
            {
                customerRepository.AddCustomer(customer);
            }

            await customerRepository.SaveAllAsync();
        }

        public static async Task SeedOwners(DataContext context)
        {
            if (await context.Owners.AnyAsync())
                return;

            var ownerData = await File.ReadAllTextAsync("Seedings/generated_owners.json");
            var owners = JsonSerializer.Deserialize<List<Owner>>(ownerData);

            if (owners == null)
                return;

            foreach (var owner in owners)
            {
                context.Owners.Add(owner);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedDeputies(DataContext context)
        {
            if (await context.Deputies.AnyAsync())
                return;

            var DeputyData = await File.ReadAllTextAsync("Seedings/generated_deputies.json");
            var deputies = JsonSerializer.Deserialize<List<Deputy>>(DeputyData);

            if (deputies == null)
                return;

            foreach (var deputy in deputies)
            {
                context.Deputies.Add(deputy);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedBuildings(DataContext context)
        {
            if (await context.Buildings.AnyAsync())
                return;

            var data = await File.ReadAllTextAsync("Seedings/generated_buildings.json");
            var buildings = JsonSerializer.Deserialize<List<Building>>(data);

            if (buildings == null)
                return;

            foreach (var building in buildings)
            {
                context.Buildings.Add(building);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedFloors(DataContext context)
        {
            if (await context.Floors.AnyAsync())
                return;

            var data = await File.ReadAllTextAsync("Seedings/generated_Floors.json");
            var floors = JsonSerializer.Deserialize<List<Floor>>(data);

            if (floors == null)
                return;

            foreach (var floor in floors)
            {
                context.Floors.Add(floor);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedRooms(DataContext context)
        {
            if (await context.Rooms.AnyAsync())
                return;

            var data = await File.ReadAllTextAsync("Seedings/generated_rooms.json");
            var rooms = JsonSerializer.Deserialize<List<Room>>(data);

            if (rooms == null)
                return;

            foreach (var room in rooms)
            {
                context.Rooms.Add(room);
            }

            await context.SaveChangesAsync();
        }

        public static async Task SeedContracts(DataContext context)
        {
            if (await context.Contracts.AnyAsync())
                return;

            var data = await File.ReadAllTextAsync("Seedings/generated_contracts.json");
            var contracts = JsonSerializer.Deserialize<List<Contract>>(data);

            if (contracts == null)
                return;

            foreach (var contract in contracts)
            {
                context.Contracts.Add(contract);
            }

            await context.SaveChangesAsync();
        }
    }
}
