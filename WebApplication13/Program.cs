using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication13.Data;
using WebApplication13.DomainModels;

namespace WebApplication13
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            await Init(host);
            await host.RunAsync();
        }

        private static async Task Init(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var rolesManager = services.GetRequiredService<RoleManager<ApplicationRole>>();
                var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                await DbInitializer.Init(userManager, rolesManager);
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
