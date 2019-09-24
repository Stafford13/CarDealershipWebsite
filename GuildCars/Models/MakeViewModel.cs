using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class MakeViewModel
    {
        public IEnumerable<Make> Makes { get; set; }
        public Make Make { get; set; }
    }
}