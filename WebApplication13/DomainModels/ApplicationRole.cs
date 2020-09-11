using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebApplication13.DomainModels
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole()
        {

        }

        public ApplicationRole(string roleName) : base(roleName)
        {
        }

        public ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}
