using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.MockRepo
{
    public class SaleMockRepo
    {
        private static List<Sale> _sales;
        static SaleMockRepo()
        {
            _sales = new List<Sale>
            {
                new Sale
                {
                    SaleId = 0,
                    UserId = "One",
                    Date = DateTime.Today,
                    Price = 10000,
                    SpecialId = 1,
                    CarId = 0,
                    Name = "John",
                    Phone = "2355477589",
                    Address1 = "1 Broadway Ave.",
                    City = "Rochester",
                    State = "NY",
                    ZipCode = 00000
                }
            };
        }
        public Sale GetById(int id)
        {
            return _sales.FirstOrDefault(c => c.SaleId == id);
        }

        public IEnumerable<Sale> GetAllSales()
        {
            return _sales;
        }

        public void Create(Sale sale)
        {
            sale.Date = DateTime.Today;

            if (_sales.Count == 0)
            {
                sale.SaleId = 0;
            }
            else sale.SaleId = _sales.Max(m => m.SaleId) + 1;

            _sales.Add(sale);
        }
    }
}
