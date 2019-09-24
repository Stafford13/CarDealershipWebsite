using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.MockRepo
{
    public class MakeMockRepo
    {
        private static List<Make> _makes;
        static MakeMockRepo()
        { 
            _makes = new List<Make>

        {
            new Make
            {
                MakeId = 1,
                MakeName = "Honda",
                DateAdded = DateTime.ParseExact("2010/01/01","yyyy/dd/MM",CultureInfo.InvariantCulture),
                UserId = "Bob"
            },
            new Make
            {
               MakeId = 2,
               MakeName = "Subaru",
               DateAdded = DateTime.ParseExact("2010/01/01","yyyy/dd/MM",CultureInfo.InvariantCulture),
               UserId = "Bob"
            },
            new Make
            {
                MakeId = 3,
                MakeName = "Kia",
                DateAdded = DateTime.ParseExact("2010/01/01","yyyy/dd/MM",CultureInfo.InvariantCulture),
                UserId = "BillyBob"
            },
        };
        }
      
        public Make GetById(int id)
        {
            return _makes.FirstOrDefault(c => c.MakeId == id);
        }

        public IEnumerable<Make> GetAllMakes()
        {
            return _makes;
        }

        public Make Create(Make make)
        {
            make.MakeId = _makes.Max(c => c.MakeId) + 1;
            make.DateAdded = DateTime.Now;
            _makes.Add(make);

            return make;
        }
    }
}
