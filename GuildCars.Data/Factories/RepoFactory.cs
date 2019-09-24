using GuildCars.Data.ADO;
using GuildCars.Data.Interfaces;
using GuildCars.Data.MockRepo;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Factories
{
    public class RepoFactory
    {
        public static ICarRepository Create()
        {

            string mode = ConfigurationManager.AppSettings["Mode"].ToString();
          
            switch (mode)
            {

                case "SampleData":
                   return new CarMockRepository();
                default:
                    throw new Exception("Mode value in app config is not valid");
            }
        }
    }
}
