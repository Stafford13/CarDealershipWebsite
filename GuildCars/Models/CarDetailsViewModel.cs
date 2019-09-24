using System;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace GuildCars.Models
{
    public class CarDetailsViewModel
    {
        public Car Car { get; set; }
        public HttpPostedFileBase ImageUpload { get; set; }
    }
}