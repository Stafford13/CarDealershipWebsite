using System.Collections.Generic;
using GuildCars.Models.Tables;

namespace GuildCars.Data.Interfaces
{
    public interface ICarRepository
    {
        Car Create(Car car);
        Car Update(Car car);
        void Delete(int id);
        Car GetById(int id);
        //IEnumerable<Car> GetNewCars(string searchText = null, decimal minPrice = 0, decimal maxPrice = 900000000, int minYear = 0, int maxYear = 2100);
        //IEnumerable<Car> GetUsedCars(string searchText = null, decimal minPrice = 0, decimal maxPrice = 900000000, int minYear = 0, int maxYear = 2100);
        //IEnumerable<Car> GetNotSoldCars(string searchText = null, decimal minPrice = 0, decimal maxPrice = 900000000, int minYear = 0, int maxYear = 2100);
        IEnumerable<Car> Search(string searchType, string searchText = null, decimal minPrice = 0, decimal maxPrice = 900000000, int minYear = 0, int maxYear = 2100);
        IEnumerable<Car> GetAllNotSold();
        IEnumerable<Car> GetAllCars();
        IEnumerable<Car> GetAllFeatures();
        void ChangeToSold(int id);
    }
}
