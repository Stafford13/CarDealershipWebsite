using GuildCars.Data.MockRepo;
using GuildCars.Models;
using GuildCars.Models.Tables;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        // GET: Admin
        [Route("Admin/vehicles")]
        public ActionResult Vehicles()
        {
            return View();
        }

        [Route("Admin/addvehicle")]
        public ActionResult addVehicle()
        {
            ModelMockRepo modelRepo = new ModelMockRepo();
            MakeMockRepo makeRepo = new MakeMockRepo();
            CarAddViewModel vm = new CarAddViewModel();
            vm.Makes = new SelectList(makeRepo.GetAllMakes(), "MakeId", "MakeName");
            vm.Models = new SelectList(modelRepo.GetAllModels(), "ModelId", "ModelName");
            return View(vm);
        }

        [Route("Admin/addvehicle")]
        [HttpPost]
        public ActionResult addVehicle(CarAddViewModel vm)
        {
            if (ModelState.IsValid)
            {
                CarMockRepository carRepo = new CarMockRepository();
                vm.Car.ImageFileName = vm.ImageUpload.FileName;
                Car car = carRepo.Create(vm.Car);
                vm.Car.CarId = car.CarId; 
                return RedirectToAction("editVehicle/" + vm.Car.CarId);
            }
            ModelMockRepo modelRepo = new ModelMockRepo();
            MakeMockRepo makeRepo = new MakeMockRepo();
            vm.Makes = new SelectList(makeRepo.GetAllMakes(), "MakeId", "MakeName");
            vm.Models = new SelectList(modelRepo.GetAllModels(), "ModelId", "ModelName");
            return View(vm);
        }

        [Route("Admin/editvehicle")]
        public ActionResult editVehicle(int id)
        {
            ModelMockRepo modelRepo = new ModelMockRepo();
            MakeMockRepo makeRepo = new MakeMockRepo();
            CarMockRepository carRepo = new CarMockRepository();
            CarEditViewModel vm = new CarEditViewModel();
            vm.Car = carRepo.GetById(id);
            vm.Car.Make = makeRepo.GetById(vm.Car.MakeId);
            vm.Car.Model = modelRepo.GetById(vm.Car.ModelId);
            vm.Makes = new SelectList(makeRepo.GetAllMakes(), "MakeId", "MakeName");
            vm.Models = new SelectList(modelRepo.GetAllModels(), "ModelId", "ModelName");
            return View(vm);
        }

        [Route("Admin/editvehicle")]
        [HttpPost]
        public ActionResult editVehicle(CarEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                CarMockRepository carRepo = new CarMockRepository();
                if (vm.ImageUpload != null)
                {
                    vm.Car.ImageFileName = vm.ImageUpload.FileName;
                }
                vm.Car = carRepo.Update(vm.Car);
                return RedirectToAction("Vehicles");
            }
            ModelMockRepo modelRepo = new ModelMockRepo();
            MakeMockRepo makeRepo = new MakeMockRepo();
            vm.Makes = new SelectList(makeRepo.GetAllMakes(), "MakeId", "MakeName");
            vm.Models = new SelectList(modelRepo.GetAllModels(), "ModelId", "ModelName");
            return View(vm);
        }

        [Route("Admin/deleteVehicle")]
        [HttpPost]
        public ActionResult DeleteVehicle(int id)
        {
            CarMockRepository carRepo = new CarMockRepository();
            carRepo.Delete(id);
            return RedirectToAction("Vehicles");
        }

        [Route("Admin/users")]
        public ActionResult Users()
        {
            return View();
        }

        [Route("Admin/editspecial")]
        public ActionResult editSpecial()
        {
            SpecialMockRepo specialRepo = new SpecialMockRepo();
            SpecialsViewModel vm = new SpecialsViewModel();
            vm.Specials = specialRepo.GetAllSpecials();
            return View(vm);
            
        }

        [HttpPost]
        [Route("Admin/editspecial")]
        public ActionResult editSpecial(SpecialsViewModel vm)
        {
            SpecialMockRepo specialRepo = new SpecialMockRepo();
            specialRepo.Create(vm.Special);
            return RedirectToAction("editSpecial");
        }

        [HttpPost]
        public ActionResult DeleteSpecial(int id)
        {
            SpecialMockRepo specialRepo = new SpecialMockRepo();
            specialRepo.Delete(id);
            return RedirectToAction("editSpecial");
        }

        [Route("Admin/makes")]
        public ActionResult Makes()
        {
            MakeMockRepo makeRepo = new MakeMockRepo();
            MakeViewModel vm = new MakeViewModel();
            vm.Makes = makeRepo.GetAllMakes();
            return View(vm);
        }

        [HttpPost]
        [Route("Admin/makes")]
        public ActionResult Makes(MakeViewModel vm)
        {
            MakeMockRepo makeRepo = new MakeMockRepo();
            var authManager = HttpContext.GetOwinContext().Authentication;
            vm.Make.UserId = authManager.User.Identity.GetUserId();
            makeRepo.Create(vm.Make);
            return RedirectToAction("Makes");
        }

        [Route("Admin/models")]
        public ActionResult Models()
        {
            ModelMockRepo modelRepo = new ModelMockRepo();
            MakeMockRepo makeRepo = new MakeMockRepo();
            ModelViewModel vm = new ModelViewModel();
            vm.Models = modelRepo.GetAllModels();
            vm.Makes = new SelectList(makeRepo.GetAllMakes(), "MakeId", "MakeName");
            return View(vm);
        }

        [HttpPost]
        [Route("Admin/models")]
        public ActionResult Models(ModelViewModel vm)
        {
            ModelMockRepo modelRepo = new ModelMockRepo();
            var authManager = HttpContext.GetOwinContext().Authentication;
            vm.Model.UserId = authManager.User.Identity.GetUserId();
            modelRepo.Create(vm.Model);
            return RedirectToAction("Models");
        }
    }
}