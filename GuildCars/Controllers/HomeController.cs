using GuildCars.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GuildCars.Data.ADO;
using GuildCars.Models.Tables;
using GuildCars.Data.MockRepo;
using GuildCars.Data.Models;

namespace GuildCars.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            SpecialMockRepo specialRepo = new SpecialMockRepo();
            FeaturedCarsViewModel vm = new FeaturedCarsViewModel();
            CarMockRepository carRepo = new CarMockRepository();
            vm.Specials = specialRepo.GetAllSpecials();
            vm.FeaturedCars = carRepo.GetAllCars().Where(m => m.isFeatured == true);
            MakeMockRepo makeRepo = new MakeMockRepo();
            ModelMockRepo modelRepo = new ModelMockRepo();
            foreach (var car in vm.FeaturedCars)
            {
                car.Make = makeRepo.GetById(car.MakeId);
                car.Model = modelRepo.GetById(car.ModelId);
            }
            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
 //get
        public ActionResult Contact()
        {
            ViewBag.Message = "Let us know how we did!";

            return View("Contact");
        }

        [HttpPost]
        public ActionResult Contact(Customer contact)
        {
            ContactRepoADO repo = new ContactRepoADO();
            repo.Insert(contact);
            return View("Index");
        }

        [Route("Home/New")]
        public ActionResult New()
        {
            ViewBag.Message = "Check out our new vehicles.";

            return View();
        }

        public ActionResult Used()
        {
            ViewBag.Message = "Check out our legacy models,";

            return View();
        }

        public ActionResult Specials()
        {
            ViewBag.Message = "";
            SpecialMockRepo specialRepo = new SpecialMockRepo();
            IEnumerable<Special> specials = specialRepo.GetAllSpecials();
            return View(specials);
        }

        public ActionResult Details()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            var model = new LoginVM();

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [Route("/Account/Login")]
        public ActionResult Login(LoginVM model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userManager = HttpContext.GetOwinContext().GetUserManager<UserManager<AppUser>>();
            var authManager = HttpContext.GetOwinContext().Authentication;

            // attempt to load the user with this password
            AppUser user = userManager.Find(model.UserName, model.Password);

            // user will be null if the password or user name is bad
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid username or password");

                return View(model);
            }
            else
            {
                // successful login, set up their cookies and send them on their way
                var identity = userManager.CreateIdentity(user, DefaultAuthenticationTypes.ApplicationCookie);
                authManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);

                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToAction("Index");
            }
        }

        [Authorize]
        [Route("/Account/Logout")]
        [ValidateAntiForgeryToken]
        public ActionResult LogOut()
        {
            HttpContext.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Index");
        }
    }
}