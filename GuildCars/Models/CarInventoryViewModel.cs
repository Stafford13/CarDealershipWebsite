using System;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class CarInventoryViewModel
    {
        public IEnumerable<ViewModelData> UsedInventory { get; set; }
        public IEnumerable<ViewModelData> NewInventory { get; set; }
    }


    public class ViewModelData
    {
        public int Year { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Count { get; set; }
        public decimal StockValue { get; set; }
    }
}