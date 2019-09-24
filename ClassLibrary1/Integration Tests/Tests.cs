using GuildCars.Data.ADO;
using NUnit.Framework;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using GuildCars.Data.MockRepo;

namespace Integration_Tests
{

    //Check out Execute format for tests
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Init()
        {
            using (var cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString))
            {
                var cmd = new SqlCommand();
                cmd.CommandText = "DbReset";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Connection = cn;
                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        [Test]
        public void CantLoadSpecials()
        {
            var repo = new SpecialRepositoryADO();

            var specials = repo.GetAll();

            Assert.AreEqual(1, specials[0].SpecialId);
            Assert.AreEqual("OneTime", specials[0].SpecialName);
            Assert.AreEqual("One time deal", specials[0].SpecialText);
            //CHECK OUT VIDEO 7
        }

        [Test]
        public void CanLoadSpecials()
        {
            var repo = new SpecialMockRepo();

            var specials = repo.GetAllSpecials();

            Assert.AreEqual(1, specials.SpecialId);
            Assert.AreEqual("A Good Special", specials[0].SpecialName);
            Assert.AreEqual("One time deal", specials[0].SpecialText);
            //CHECK OUT VIDEO 7
        }

        [Test]
        public void CanLoadCar()
        {
            var repo = new CarRepositoryADO();
            var car = repo.GetById(1);

            Assert.IsNotNull(car);

            //values (1, 'SUV', '2010', 'Black', 'Tan', '3500', '1', 
            //'Used', '40000', '45000','1', '1', 'Car1'),
            Assert.AreEqual(1, car.CarId);
            Assert.AreEqual("SUV", car.Body);
            Assert.AreEqual("2010", car.Year);
            Assert.AreEqual("Black", car.ExColor);
            Assert.AreEqual("Tan", car.IntColor);
            Assert.AreEqual("3500", car.Mileage);
            Assert.AreEqual("1", car.Transmission);
            Assert.AreEqual("Used", car.Type);
            Assert.AreEqual("40000", car.MSRP);
            Assert.AreEqual("45000", car.Price);
            Assert.AreEqual("Honda", car.Make.MakeName);
            Assert.AreEqual("Accord", car.Model.ModelName);
            Assert.AreEqual("Car1", car.ImageFileName);
        }

        [Test]
        public void NotFoundCarReturnsNull()
        {
            var repo = new CarRepositoryADO();
            var car = repo.GetById(100000);

            Assert.IsNull(car);
        }

        [Test]
        public void CanAddCar()
        {
            Car carToAdd = new Car();
            var repo = new CarRepositoryADO();

            carToAdd.CarId = 1;
            carToAdd.Body = "SUV";
            carToAdd.Year = 2010;
            carToAdd.ExColor = "Black";
            carToAdd.IntColor = "Tan";
            carToAdd.Transmission = "Auto";
            carToAdd.Type = "Used";
            carToAdd.MSRP = 40000;
            carToAdd.Price = 45000;
            carToAdd.Make.MakeName = "Honda";
            carToAdd.Model.ModelName = "Accord";
            carToAdd.ImageFileName = "Car1.PNG";

            repo.Insert(carToAdd);

            Assert.AreEqual(2, carToAdd.CarId);
        }

        [Test]
        public void CanUpdateCar()
        {
            Car carToAdd = new Car();
            var repo = new CarRepositoryADO();

            carToAdd.CarId = 1;
            carToAdd.Body = "SUV";
            carToAdd.Year = 2010;
            carToAdd.ExColor = "Black";
            carToAdd.IntColor = "Tan";
            carToAdd.Transmission = "Manual";
            carToAdd.Type = "Used";
            carToAdd.MSRP = 40000;
            carToAdd.Price = 45000;
            carToAdd.Make.MakeName = "Honda";
            carToAdd.Model.ModelName = "Accord";
            carToAdd.ImageFileName = "Car1.PNG";

            repo.Insert(carToAdd);

            carToAdd.ExColor = "Silver";
            carToAdd.IntColor = "Grey";
            carToAdd.Year = 2013;
            carToAdd.Body = "Sedan";
            carToAdd.Transmission = "false";
            carToAdd.ImageFileName = "Car2.PNG";

            repo.Update(carToAdd);

            var updatedCar = repo.GetById(2);

            Assert.AreEqual("Silver", updatedCar.ExColor);
            Assert.AreEqual("Grey", updatedCar.IntColor);
            Assert.AreEqual(2013, updatedCar.Year);
            Assert.AreEqual("Sedanr", updatedCar.Body);
            Assert.AreEqual(false, updatedCar.Transmission);
            Assert.AreEqual("Car2.PNG", updatedCar.ImageFileName);
        }

        [Test]
        public void CanDeleteCar()
        {
            Car carToAdd = new Car();
            var repo = new CarRepositoryADO();

            carToAdd.CarId = 1;
            carToAdd.Body = "SUV";
            carToAdd.Year = 2010;
            carToAdd.ExColor = "Black";
            carToAdd.IntColor = "Tan";
            carToAdd.Transmission = "true";
            carToAdd.Type = "Used";
            carToAdd.MSRP = 40000;
            carToAdd.Price = 45000;
            carToAdd.Make.MakeName = "Honda";
            carToAdd.Model.ModelName = "Accord";
            carToAdd.ImageFileName = "Car1.PNG";

            repo.Insert(carToAdd);

            var loaded = repo.GetById(2);
            Assert.IsNotNull(loaded);

            repo.Delete(2);
            loaded = repo.GetById(2);

            Assert.IsNull(loaded);
        }
    }
}
