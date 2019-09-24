using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class SaleReportViewModel
    {
        public IEnumerable<ViewModelInfo> SoldInventory { get; set; }
        public Sale UserId { get; set; }
    }

    public class ViewModelInfo
    {
        public string User { get; set; }
        public int TotalSale { get; set; }
        public int TotalVehicle { get; set; }
    }
}