using GuildCars.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Owin;
using Microsoft.Owin;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.Cookies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(SecurityDb.Create);

            app.CreatePerOwinContext<UserManager<AppUser>>((options, context) => new UserManager<AppUser>(new UserStore<AppUser>(context.Get<SecurityDb>())));

            app.CreatePerOwinContext<RoleManager<AppRole>>((options, context) => new RoleManager<AppRole>(new RoleStore<AppRole>(context.Get<SecurityDb>())));

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login")
            });
        }
    }
}