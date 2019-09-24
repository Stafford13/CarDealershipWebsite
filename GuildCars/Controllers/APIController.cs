using GuildCars.Data.ADO;
using GuildCars.Data.Factories;
using GuildCars.Data.Interfaces;
using GuildCars.Data.MockRepo;
using GuildCars.Models.Tables;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace GuildCars.Controllers
{
    public class APIController : ApiController
    {
        [Route("api/inventory/search/{type}/{term}/{minPrice}/{maxPrice}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string type, string term, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        {
            CarMockRepository repo = new CarMockRepository();
            IEnumerable<Car> found = repo.Search(type, term, minPrice, maxPrice, minYear, maxYear);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        [Route("api/sales/search/{searchType}/{User}/{minYear}/{maxYear}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult Search(string searchType, string User, int minYear, int maxYear)
        {
            CarMockRepository repo = new CarMockRepository();
            IEnumerable<Car> found = repo.Search(searchType, User, minYear, maxYear);

            if (found == null)
            {
                return NotFound();
            }

            return Ok(found);
        }

        [Route("modellist/{make}")]
        [AcceptVerbs("GET")]
        public IHttpActionResult ModelList(int make)
        {
            ModelMockRepo repo = new ModelMockRepo();
            IEnumerable<Model> found = repo.GetAllModels().Where(m => m.MakeId == make);

            if (found == null)
            {
                return NotFound();
            }
            return Ok(found);
        }
    }
}
