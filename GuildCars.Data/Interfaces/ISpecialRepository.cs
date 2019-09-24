using System.Collections.Generic;
using GuildCars.Models.Tables;

namespace GuildCars.Data.Interfaces
{
    public interface ISpecialRepository
    {
        List<Special> GetAll();
    }
}

//create
//    read
//    delete