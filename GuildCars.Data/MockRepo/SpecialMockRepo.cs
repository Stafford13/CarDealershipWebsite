using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.MockRepo
{
    public class SpecialMockRepo
    {
        private static List<Special> _specials;
        static SpecialMockRepo()
        {
            _specials = new List<Special>

        {
            new Special
            {
               SpecialId = 1,
               SpecialName = "A good special",
               SpecialText = "A pretty good special!"
            },
            new Special
            {
              SpecialId = 2,
              SpecialName = "A great special",
              SpecialText = "A pretty great special!"
            },
            new Special
            {
              SpecialId = 3,
              SpecialName = "An amazing special",
              SpecialText = "A pretty amazing special!"
            },
        };
        }
        public Special GetById(int id)
        {
            return _specials.FirstOrDefault(c => c.SpecialId == id);
        }

        public IEnumerable<Special> GetAllSpecials()
        {
            return _specials;
        }

        public Special Create(Special special)
        {
            int id = _specials.Max(c => c.SpecialId) + 1;
            _specials.Add(special);

            return special;
        }

        public void Delete(int id)
        {
            Special special = _specials.FirstOrDefault(c => c.SpecialId == id);
            _specials.Remove(special);
        }
    }
}
