using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildCars.Models
{
    public class UpdateAccountViewModel
    {
        public string SpecialId { get; set; }
        public string EmailAddress { get; set; }

        public IEnumerable<SelectListItem> Specials { get; set; }
    }
}