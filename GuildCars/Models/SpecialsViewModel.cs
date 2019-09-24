using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class SpecialsViewModel
    {
        public IEnumerable<Special> Specials { get; set; }
        public Special Special { get; set; }
    }
}