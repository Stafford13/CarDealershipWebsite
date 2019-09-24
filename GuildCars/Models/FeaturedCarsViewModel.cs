using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Models
{
    public class FeaturedCarsViewModel
    {
        public IEnumerable<Special> Specials { get; set; }
        public IEnumerable<Car> FeaturedCars { get; set; }
    }
}
