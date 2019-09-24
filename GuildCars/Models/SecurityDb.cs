using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class SecurityDb : IdentityDbContext<AppUser>
    {
        public SecurityDb() : base("DefaultConnection")
        {

        }

        public static SecurityDb Create()
        {
            return new SecurityDb();
        }
    }

    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class AppRole : IdentityRole
    {

    }
    
}