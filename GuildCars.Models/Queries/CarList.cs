using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Models.Queries
{
    public class CarList
    {
        public int CarId { get; set; }
        public string Body { get; set; }
        public int Year { get; set; }
        public int Mileage { get; set; }
        public string ExColor { get; set; }
        public string IntColor { get; set; }
        public bool Transmission { get; set; }
        public string Type { get; set; }
        public int MSRP { get; set; }
        public int Price { get; set; }
        public string ImageFileName { get; set; }
        public Make MakeName { get; set; }
        public Model ModelName { get; set; }
    }
}
