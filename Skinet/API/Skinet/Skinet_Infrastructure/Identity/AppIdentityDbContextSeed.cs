using Microsoft.AspNetCore.Identity;
using Skinet_Core.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skinet_Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Inay",
                    Email = "inaytest@yopmail.com",
                    UserName = "inaytest@yopmail.com",
                    Address = new Address
                    {
                        FirstName = "Inay",
                        LastName = "Jha",
                        Street = "2 The street",
                        City = "New York",
                        State = "NY",
                        ZipCode = "90210"
                    }
                };

                await userManager.CreateAsync(user,"123456Aa@");
            }
        }
    }
}
