using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.MockRepo
{
    public class ModelMockRepo
    {
        private static List<Model> _models;
        static ModelMockRepo()
        {
            _models = new List<Model>

        {
            new Model
            {
               ModelId = 1,
               ModelName = "Accord",
               MakeId = 1,
               DateAdded = DateTime.ParseExact("2010/01/01","yyyy/dd/MM",CultureInfo.InvariantCulture)
            },
            new Model
            {
               ModelId = 2,
               ModelName = "Civic",
               MakeId = 1,
               DateAdded = DateTime.ParseExact("2010/01/01","yyyy/dd/MM",CultureInfo.InvariantCulture)
            },
            new Model
            {
               ModelId = 3,
               ModelName = "Odyssey",
               MakeId = 1,
               DateAdded = DateTime.ParseExact("2010/01/01","yyyy/dd/MM",CultureInfo.InvariantCulture)
            },
            new Model
            {
               ModelId = 4,
               ModelName = "Forester",
               MakeId = 2,
               DateAdded = DateTime.ParseExact("2010/01/01","yyyy/dd/MM",CultureInfo.InvariantCulture)
            },
            new Model
            {
               ModelId = 5,
               ModelName = "Soul",
               MakeId = 3,
               DateAdded = DateTime.ParseExact("2010/01/01","yyyy/dd/MM",CultureInfo.InvariantCulture)
            },
        };
        }

        public Model GetById(int id)
        {
            return _models.FirstOrDefault(c => c.ModelId == id);
        }

        public IEnumerable<Model> GetAllModels()
        {
            return _models;
        }

        public Model Create(Model model)
        {
            model.ModelId = _models.Max(c => c.ModelId) + 1;
            model.DateAdded = DateTime.Now;
            _models.Add(model);

            return model;
        }
    }
}
