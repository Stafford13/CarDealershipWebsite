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
    public class ModelRepoADO
    {
        public void Insert(Model model)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter param = new SqlParameter("@CustomerId", SqlDbType.Int);
                //param.Direction = ParameterDirection.Output;

                //cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@ModelName", model.ModelName);
                cmd.Parameters.AddWithValue("@DateAdded", model.DateAdded);

                cn.Open();

                cmd.ExecuteNonQuery();

                //customer.CustomerId = (int)param.Value;
            }
        }
    }
}
