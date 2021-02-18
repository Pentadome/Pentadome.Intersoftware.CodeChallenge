using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pentadome.Intersoftware.CodeChallenge.Authentication
{
    internal sealed class ApplicationRole : IdentityRole
    {
        public const string User = "User";

        public const string Admin = "Admin";

        public ApplicationRole(string roleName) : base(roleName)
        {
        }

        public static ApplicationRole UserRole { get; } = new ApplicationRole(User);

        public static ApplicationRole AdminRole { get; } = new ApplicationRole(Admin);
    }
}
