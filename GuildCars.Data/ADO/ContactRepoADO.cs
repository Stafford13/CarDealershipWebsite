using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.ADO
{
    public class ContactRepoADO
    {
        public void Insert(Customer customer)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CustomerInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter param = new SqlParameter("@CustomerId", SqlDbType.Int);
                //param.Direction = ParameterDirection.Output;

                //cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@LastName", customer.LastName);
                cmd.Parameters.AddWithValue("@Phone", customer.Phone);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@Message", customer.Message);

                cn.Open();

                cmd.ExecuteNonQuery();

                //customer.CustomerId = (int)param.Value;
            }
        }
    }
}
