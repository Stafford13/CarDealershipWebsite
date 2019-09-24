using GuildCars.Data.MockRepo;
using GuildCars.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    //[Authorize(Roles = "sales,admin")]
    public class SaleController : Controller
    {
        // GET: Sale
        [Route("sale/index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("sale/purchase/{id}")]
        public ActionResult purchase(int id)
        {
            CarMockRepository carRepo = new CarMockRepository();
            MakeMockRepo makeRepo = new MakeMockRepo();
            ModelMockRepo modelRepo = new ModelMockRepo();
            PurchaseCarViewModel vm = new PurchaseCarViewModel();
            vm.Car = carRepo.GetById(id);
            vm.Car.Make = makeRepo.GetById(vm.Car.MakeId);
            vm.Car.Model = modelRepo.GetById(vm.Car.ModelId);
            return View(vm);
        }

        [HttpPost]
        [Route("sale/purchase/{id}")]
        public ActionResult purchase(PurchaseCarViewModel vm)
        {
            CarMockRepository carRepo = new CarMockRepository();
            MakeMockRepo makeRepo = new MakeMockRepo();
            ModelMockRepo modelRepo = new ModelMockRepo();
            SaleMockRepo saleRepo = new SaleMockRepo();

            vm.Car = carRepo.GetById(vm.Car.CarId);

            //if (ModelState.IsValid)
            //{
                carRepo.ChangeToSold(vm.Car.CarId);

                var authManager = HttpContext.GetOwinContext().Authentication;
                vm.Sale.UserId = authManager.User.Identity.GetUserId();
                vm.Sale.CarId = vm.Car.CarId;

                saleRepo.Create(vm.Sale);
                return RedirectToAction("Index");
            //}

            //vm.Car = carRepo.GetById(vm.Car.CarId);
            //vm.Car.Make = makeRepo.GetById(vm.Car.MakeId);
            //vm.Car.Model = modelRepo.GetById(vm.Car.ModelId);

            //return View(vm);
        }
    }
}