using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace WebApplication13.DomainModels
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserRole> UserRoles { get; } = new List<ApplicationUserRole>();
    }
}
