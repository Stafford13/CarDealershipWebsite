using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.MockRepo
{
    public class CustomerMockRepo
    {
        private static List<Customer> _customers;
        public Customer GetById(int id)
        {
            return _customers.FirstOrDefault(c => c.CustomerId == id);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customers;
        }
    }
}
