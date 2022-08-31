using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Skinet_Core.Entities.Identity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Skinet_API.Extensions
{
    public static class UserManagerExtension
    {
        //Find address by principal claim
        public static async Task<AppUser> FindUserByClaimPrincipleEmailWithAddressAsync(this UserManager<AppUser> input, ClaimsPrincipal 
            user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

           return await input.Users.Include(x=>x.Address).SingleOrDefaultAsync(x => x.Email == email);
        }

        //Find Email By Pricipal claim
        public static async Task<AppUser> FindByEmailFromClaimsPrinciple(this UserManager<AppUser> input, ClaimsPrincipal 
            user)
        {
            var email = user?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

            return await input.Users.SingleOrDefaultAsync(x => x.Email == email);
        }
    }
}
