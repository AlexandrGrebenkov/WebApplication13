using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication13.DomainModels;

namespace WebApplication13.Data
{
    public class DbInitializer
    {
        public static async Task Init(UserManager<ApplicationUser> userManager, RoleManager<ApplicationRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }

        private static async Task SeedUsers(UserManager<ApplicationUser> userManager)
        {
            var user = await userManager.FindByNameAsync("example@mail.com");
            if (user == null)
            {
                user = new ApplicationUser()
                {
                    Email = "example@mail.com",
                    UserName = "example@mail.com",
                };
                var result = await userManager.CreateAsync(user);
                result = await userManager.AddPasswordAsync(user, "123#Qwerty");
                result = await userManager.AddToRoleAsync(user, "admin");
            }
        }

        private static async Task SeedRoles(RoleManager<ApplicationRole> roleManager)
        {
            var roleNames = new[] { "admin", "customer" };
            foreach (var roleName in roleNames)
            {
                if (await roleManager.FindByNameAsync(roleName) == null)
                {
                    await roleManager.CreateAsync(new ApplicationRole(roleName));
                }
            }
        }
    }
}
