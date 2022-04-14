using System;
using System.Threading.Tasks;
using Liquid.Core.Entities;
using Liquid.Core.Enums;
using Liquid.Core.Services.Interfaces.Security;
using Microsoft.EntityFrameworkCore;

namespace Liquid.Persistence.Contexts
{
    public static class DbInitializer
    {
        public static async Task Initialize(ILiquidContext context, IPasswordHasher passwordHasher)
        {
            await InitializeUsers(context, passwordHasher);
        }

        private static async Task InitializeUsers(ILiquidContext context, IPasswordHasher passwordHasher)
        {
            if (await context.Users.CountAsync() == 0)
            {
                var salt = Guid.NewGuid().ToByteArray();
                var password = "Asanka@2022";
                var user = new User
                {
                    FirstName = "Asanka",
                    LastName = "Mawilmada",
                    DateOfBirth = new DateTime(1979, 9, 26),
                    Username = "asankam",
                    Hash = await passwordHasher.Hash(password, salt),
                    Salt = salt,
                    Role = UserRole.Administrator,
                    Active = true
                };

                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }
    }
}