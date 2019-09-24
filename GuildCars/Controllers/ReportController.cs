using GuildCars.Data.MockRepo;
using GuildCars.Models;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Controllers
{
    public class ReportController : Controller
    {
        // GET: Report
        [Route("reports/index")]
        public ActionResult Index()
        {
            return View();
        }

        [Route("reports/inventory")]
        public ActionResult Inventory()
        {
            CarInventoryViewModel inventoryViewModel = new CarInventoryViewModel();
            CarMockRepository carMock = new CarMockRepository();
            MakeMockRepo makeRepo = new MakeMockRepo();
            ModelMockRepo modelRepo = new ModelMockRepo();

            IEnumerable<Car> allCars = carMock.GetAllCars();
            foreach(Car item in allCars)
            {
                item.Make = makeRepo.GetById(item.MakeId);
                item.Model = modelRepo.GetById(item.ModelId);
            }

            IEnumerable<Car> newVehicles = allCars.Where(v => v.Type == "New");
            IEnumerable<Car> usedVehicles = allCars.Where(v => v.Type == "Used");

            inventoryViewModel.UsedInventory = Inventory(usedVehicles);
            inventoryViewModel.NewInventory = Inventory(newVehicles);
            return View(inventoryViewModel);
        }

        private IEnumerable<ViewModelData> Inventory(IEnumerable<Car> cars)
        {
            var newDataQ = from car in cars
                           group car by new { year = car.Year, model = car.Model.ModelName, make = car.Make.MakeName }
                            into g
                           select new ViewModelData
                           {
                               Year = g.Key.year,
                               Make = g.Key.make,
                               Model = g.Key.model,
                               Count = g.Count(),
                               StockValue = g.Sum(c => c.MSRP)
                           };

            return newDataQ;
        }

        [Route("reports/sales")]
        public ActionResult salesReport()
        {
            SaleReportViewModel SaleViewModel = new SaleReportViewModel();
            CarMockRepository carMock = new CarMockRepository();

            IEnumerable<Car> allCars = carMock.GetAllCars();
            IEnumerable<Car> soldVehicles = allCars.Where(v => v.isSold == true);

            return View(SaleViewModel);
        }
    }
}