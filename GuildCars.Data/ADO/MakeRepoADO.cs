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
    public class MakeRepoADO
    {
        public void Insert(Make make)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("MakeInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                //SqlParameter param = new SqlParameter("@CustomerId", SqlDbType.Int);
                //param.Direction = ParameterDirection.Output;

                //cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@MakeName", make.MakeName);
                cmd.Parameters.AddWithValue("@DateAdded", make.DateAdded);
                //cmd.Parameters.AddWithValue("@ModelId", make.model.modelId);

                cn.Open();

                cmd.ExecuteNonQuery();

                //customer.CustomerId = (int)param.Value;
            }
        }
    }
}
