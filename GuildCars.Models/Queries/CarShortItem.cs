using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    class CarShortItem
    {
        public int CarId { get; set; }
        public string Body { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string ExColor { get; set; }
        public string IntColor { get; set; }
    }
}
