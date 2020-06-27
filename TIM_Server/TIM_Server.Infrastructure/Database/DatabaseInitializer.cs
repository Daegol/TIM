using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TIM_Server.Core.Model;

namespace TIM_Server.Infrastructure.Database
{
    public static class DatabaseInitializer
    {
        public static async Task PrepPopulation(IApplicationBuilder app)
        {
            using var serviceScope = app.ApplicationServices.CreateScope();
            await SeedData(serviceScope.ServiceProvider.GetService<DatabaseContext>());
        }

        private static async Task SeedData(DatabaseContext context)
        {
            Console.WriteLine("Appling Migrations...");

            await context.Database.MigrateAsync();

            if (!context.Admins.Any())
            {
                Console.WriteLine("Adding data to admins - seeding...");
                await context.AddAsync(AddAdmin());
            }

            if (!context.Commanders.Any())
            {
                Console.WriteLine("Adding data to commanders - seeding...");
                foreach (var commander in AddCommander())
                {
                    await context.AddAsync(commander);
                }
            }

            if (!context.Companies.Any())
            {
                Console.WriteLine("Adding data to companies - seeding...");
                foreach (var addCompany in AddCompanies())
                {
                    await context.AddAsync(addCompany);
                }
            }

            if (!context.Soldiers.Any())
            {
                Console.WriteLine("Adding data to soldiers - seeding...");
                foreach (var addCompany in AddSoldiers())
                {
                    await context.AddAsync(addCompany);
                }
            }

            if (!context.Services.Any())
            {
                Console.WriteLine("Adding data to services - seeding...");
                await context.AddAsync(AddService());
            }

            if (!context.Leaves.Any())
            {
                Console.WriteLine("Adding data to leaves - seeding...");
                foreach (var addCompany in AddLeaves())
                {
                    await context.AddAsync(addCompany);
                }
            }

            await context.SaveChangesAsync();
            Console.WriteLine("Already have data - not seeding");
        }

        #region MockDb

        private static Admin AddAdmin()
        {
            var hmac = new HMACSHA512();
            return new Admin
            {
                Id = Guid.Parse("9f1d1381-eb1e-4db1-89a3-67ae028c75ee"),
                City = "Warszawa",
                Email = "admin@admin.pl",
                FirstName = "AdminName1",
                LastName = "AdminLastName1",
                HouseNumber = "2",
                MilitaryRank = "por.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("admin")),
                PasswordSalt = hmac.Key,
                Pesel = "12345678901",
                PhoneNumber = "123123123",
                PostCode = "33-123",
                Street = "Ulica",
                Role = "Admin"
            };
        }

        private static List<Commander> AddCommander()
        {
            var hmac = new HMACSHA512();
            var commanders = new List<Commander>();
            commanders.Add(new Commander
            {
                Id = Guid.Parse("78c0e9bc-bea4-4970-a10d-aad3c301c91b"),
                City = "Warszawa",
                Email = "commander1@commander.pl",
                FirstName = "CommanderName1",
                LastName = "CommanderLastName1",
                HouseNumber = "3",
                MilitaryRank = "por.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("commander")),
                PasswordSalt = hmac.Key,
                Pesel = "22345678901",
                PhoneNumber = "223123123",
                PostCode = "33-123",
                Street = "Ulica1",
                Role = "Commander"
            });
            commanders.Add(new Commander
            {
                Id = Guid.Parse("2f375abc-36c0-4ec2-88ce-ee087522a894"),
                City = "Warszawa",
                Email = "commander2@commander.pl",
                FirstName = "CommanderName2",
                LastName = "CommanderLastName2",
                HouseNumber = "3",
                MilitaryRank = "por.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("commander")),
                PasswordSalt = hmac.Key,
                Pesel = "32345678901",
                PhoneNumber = "323123123",
                PostCode = "33-123",
                Street = "Ulica2",
                Role = "Commander"
            });
            return commanders;
        }

        private static List<Company> AddCompanies()
        {
            var companies = new List<Company>();

            companies.Add(new Company
            {
                Id = Guid.Parse("a55380bb-7054-4e9f-9e22-def10881022c"),
                Name = "1 kp",
                CommanderId = Guid.Parse("2f375abc-36c0-4ec2-88ce-ee087522a894")
            });
            companies.Add(new Company
            {
                Id = Guid.Parse("ac8f6e9b-6862-4e8d-b995-fce8f848317c"),
                Name = "2 kp",
                CommanderId = Guid.Parse("78c0e9bc-bea4-4970-a10d-aad3c301c91b")
            });
            return companies;
        }

        private static List<Soldier> AddSoldiers()
        {
            var soldiers = new List<Soldier>();
            var hmac = new HMACSHA512();

            soldiers.Add(new Soldier
            {
                Id = Guid.Parse("99033094-d116-4eb1-9c91-acb08f7f08b7"),
                City = "Warszawa",
                Email = "soldier1@soldier.pl",
                FirstName = "SoldierName1",
                LastName = "SoldierLastName1",
                HouseNumber = "1",
                MilitaryRank = "szer. pchor.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("soldier")),
                PasswordSalt = hmac.Key,
                Pesel = "11111111111",
                PhoneNumber = "111111111",
                PostCode = "11-111",
                Street = "Ulica1",
                Role = "Soldier",
                Status = "PJ",
                CompanyId = Guid.Parse("a55380bb-7054-4e9f-9e22-def10881022c")
            });

            soldiers.Add(new Soldier
            {
                Id = Guid.Parse("5eda53ea-7fdb-4880-afff-189e1cd67cd0"),
                City = "Warszawa",
                Email = "soldier2@soldier.pl",
                FirstName = "SoldierName2",
                LastName = "SoldierLastName2",
                HouseNumber = "2",
                MilitaryRank = "szer. pchor.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("soldier")),
                PasswordSalt = hmac.Key,
                Pesel = "21111111111",
                PhoneNumber = "211111111",
                PostCode = "21-111",
                Street = "Ulica2",
                Role = "Soldier",
                Status = "SŁ",
                CompanyId = Guid.Parse("a55380bb-7054-4e9f-9e22-def10881022c")
            });
            soldiers.Add(new Soldier
            {
                Id = Guid.Parse("8c4c9c6a-e668-43d9-997f-cea816a0309e"),
                City = "Warszawa",
                Email = "soldier3@soldier.pl",
                FirstName = "SoldierName3",
                LastName = "SoldierLastName3",
                HouseNumber = "3",
                MilitaryRank = "szer. pchor.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("soldier")),
                PasswordSalt = hmac.Key,
                Pesel = "31111111111",
                PhoneNumber = "311111111",
                PostCode = "31-111",
                Street = "Ulica3",
                Role = "Soldier",
                Status = "PJ",
                CompanyId = Guid.Parse("a55380bb-7054-4e9f-9e22-def10881022c")
            });
            soldiers.Add(new Soldier
            {
                Id = Guid.Parse("395e4f66-74ef-4e1c-a119-3e64c963dc82"),
                City = "Warszawa",
                Email = "soldier4@soldier.pl",
                FirstName = "SoldierName4",
                LastName = "SoldierLastName4",
                HouseNumber = "4",
                MilitaryRank = "szer. pchor.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("soldier")),
                PasswordSalt = hmac.Key,
                Pesel = "41111111111",
                PhoneNumber = "141111111",
                PostCode = "41-111",
                Street = "Ulica4",
                Role = "Soldier",
                Status = "X",
                CompanyId = Guid.Parse("a55380bb-7054-4e9f-9e22-def10881022c")
            });
            soldiers.Add(new Soldier
            {
                Id = Guid.Parse("6750f544-fd1c-4eac-a165-4a09fbb93f3d"),
                City = "Warszawa",
                Email = "soldier5@soldier.pl",
                FirstName = "SoldierName5",
                LastName = "SoldierLastName5",
                HouseNumber = "5",
                MilitaryRank = "szer. pchor.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("soldier")),
                PasswordSalt = hmac.Key,
                Pesel = "51111111111",
                PhoneNumber = "511111111",
                PostCode = "51-111",
                Street = "Ulica5",
                Role = "Soldier",
                Status = "X",
                CompanyId = Guid.Parse("a55380bb-7054-4e9f-9e22-def10881022c")
            });
            soldiers.Add(new Soldier
            {
                Id = Guid.Parse("b06d42fd-3939-49c6-b1cc-60deda979e61"),
                City = "Warszawa",
                Email = "soldier6@soldier.pl",
                FirstName = "SoldierName6",
                LastName = "SoldierLastName6",
                HouseNumber = "6",
                MilitaryRank = "szer. pchor.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("soldier")),
                PasswordSalt = hmac.Key,
                Pesel = "61111111111",
                PhoneNumber = "611111111",
                PostCode = "61-111",
                Street = "Ulica6",
                Status = "X",
                Role = "Soldier",
                CompanyId = Guid.Parse("ac8f6e9b-6862-4e8d-b995-fce8f848317c")
            });
            soldiers.Add(new Soldier
            {
                Id = Guid.Parse("3c87633b-958a-4d87-8204-366fd49bfe10"),
                City = "Warszawa",
                Email = "soldier7@soldier.pl",
                FirstName = "SoldierName7",
                LastName = "SoldierLastName7",
                HouseNumber = "7",
                MilitaryRank = "szer. pchor.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("soldier")),
                PasswordSalt = hmac.Key,
                Pesel = "71111111111",
                PhoneNumber = "711111111",
                PostCode = "71-111",
                Street = "Ulica7",
                Role = "Soldier",
                Status = "X",
                CompanyId = Guid.Parse("ac8f6e9b-6862-4e8d-b995-fce8f848317c")
            });
            soldiers.Add(new Soldier
            {
                Id = Guid.Parse("7c498d10-f1a6-4eec-a75a-7680d3f11120"),
                City = "Warszawa",
                Email = "soldier8@soldier.pl",
                FirstName = "SoldierName8",
                LastName = "SoldierLastName8",
                HouseNumber = "8",
                MilitaryRank = "szer. pchor.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("soldier")),
                PasswordSalt = hmac.Key,
                Pesel = "81111111111",
                PhoneNumber = "811111111",
                PostCode = "81-111",
                Street = "Ulica8",
                Role = "Soldier",
                Status = "X",
                CompanyId = Guid.Parse("ac8f6e9b-6862-4e8d-b995-fce8f848317c")
            });
            soldiers.Add(new Soldier
            {
                Id = Guid.Parse("41d03357-27e2-466e-8216-2746042f6442"),
                City = "Warszawa",
                Email = "soldier9@soldier.pl",
                FirstName = "SoldierName9",
                LastName = "SoldierLastName9",
                HouseNumber = "9",
                MilitaryRank = "szer. pchor.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("soldier")),
                PasswordSalt = hmac.Key,
                Pesel = "91111111111",
                PhoneNumber = "911111111",
                PostCode = "91-111",
                Street = "Ulica9",
                Role = "Soldier",
                Status = "X",
                CompanyId = Guid.Parse("ac8f6e9b-6862-4e8d-b995-fce8f848317c")
            });
            soldiers.Add(new Soldier
            {
                Id = Guid.Parse("da3580ed-9e66-4521-83bf-487fc9dc1a15"),
                City = "Warszawa",
                Email = "soldier0@soldier.pl",
                FirstName = "SoldierName0",
                LastName = "SoldierLastName0",
                HouseNumber = "0",
                MilitaryRank = "szer. pchor.",
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("soldier")),
                PasswordSalt = hmac.Key,
                Pesel = "01111111111",
                PhoneNumber = "011111111",
                PostCode = "01-111",
                Street = "Ulica0",
                Role = "Soldier",
                Status = "X",
                CompanyId = Guid.Parse("ac8f6e9b-6862-4e8d-b995-fce8f848317c")
            });
            return soldiers;
        }

        public static Service AddService()
        {
            var service = new Service
            {
                Id = Guid.Parse("a91e3c1b-f72f-431e-9b67-3c9b5e0db33e"),
                Type = "Kompania",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(1),
                SoldierId = Guid.Parse("5eda53ea-7fdb-4880-afff-189e1cd67cd0"),
                CompanyId = Guid.Parse("a55380bb-7054-4e9f-9e22-def10881022c")
            };

            return service;
        }

        public static List<Leave> AddLeaves()
        {
            var leaves = new List<Leave>();

            leaves.Add(new Leave
            {
                Id = Guid.Parse("dcdbe968-ac2b-4389-9cc7-eec474ae5be6"),
                StartDate = DateTime.Today.AddDays(-1),
                EndDate = DateTime.Today.AddDays(1),
                Where = "Warszawa",
                Type = "Pj",
                Returned = false,
                SoldierId = Guid.Parse("99033094-d116-4eb1-9c91-acb08f7f08b7")
            });

            leaves.Add(new Leave
            {
                Id = Guid.Parse("032c389e-6a5e-44c7-93bb-944fadde98ea"),
                StartDate = DateTime.Today.AddDays(-1),
                EndDate = DateTime.Today.AddDays(1),
                Where = "Warszawa",
                Type = "Pj",
                Returned = false,
                SoldierId = Guid.Parse("8c4c9c6a-e668-43d9-997f-cea816a0309e")
            });

            return leaves;
        }

        #endregion
    }
}