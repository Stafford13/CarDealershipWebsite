using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GuildCars.Data.ADO;
using GuildCars.Models.Tables;
using NUnit.Framework;

namespace GuildCars.Tests.IntegrationTests
{
    [TestFixture]
    public class ADOTests
    {

        [Test]
        public void CanLoadSpecials()
        {
            var repo = new SpecialRepositoryADO();

            List<Special> special = repo.GetAll();

            Assert.AreEqual(3, special.Count());

            Assert.AreEqual("2", special[2].SpecialId);
            Assert.AreEqual("FallSale", special[2].SpecialName);
            Assert.AreEqual("This is the Fall Sale", special[2].SpecialText);
        }
    }
}
