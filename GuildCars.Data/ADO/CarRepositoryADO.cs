using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;

namespace GuildCars.Data.ADO
{
    public class CarRepositoryADO  /* ICarRepository*/
    {
        public void Delete(int CarId)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarDelete", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CarId", CarId);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        public List<Car> GetAll()
        {
            List<Car> cars = new List<Car>();

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarSelectAll", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        Car currentRow = new Car();
                        currentRow.CarId = (int)dr["CarId"];
                        currentRow.Type = dr["Type"].ToString();

                        cars.Add(currentRow);
                    }
                }
            }
            return cars;
        }

        public Car GetById(int CarId)
        {
            Car car = null;

            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarSelect", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CarId", CarId);
                cn.Open();

                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    if (dr.Read())
                    {
                        car = new Car();
                        car.CarId = (int)dr["CarId"];
                        car.Body = dr["Body"].ToString();
                        car.Year = (int)dr["Year"];
                        car.ExColor = dr["ExColor"].ToString();
                        car.IntColor = dr["IntColor"].ToString();
                        car.Mileage = (int)dr["Mileage"];
                        car.Transmission = dr["Transmission"].ToString();
                        car.Type = dr["Type"].ToString();
                        car.MSRP = (int)dr["MSRP"];
                        car.Price = (int)dr["Price"];
                        //car.MakeName.MakeId = (int)dr["MakeId"];
                        //car.ModelName.ModelId = (int)dr["ModelId"];
                        car.ImageFileName = dr["ImageFileName"].ToString();
                    }
                }
            }

            return car;
        }

        public void Insert(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarInsert", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter("@CarId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;

                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@CarId", car.CarId);
                cmd.Parameters.AddWithValue("@Body", car.Body);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@ExColor", car.ExColor);
                cmd.Parameters.AddWithValue("@IntColor", car.IntColor);
                cmd.Parameters.AddWithValue("@Transmission", car.Transmission);
                cmd.Parameters.AddWithValue("@Type", car.Type);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@Price", car.Price);
                //cmd.Parameters.AddWithValue("@MakeId", car.MakeId);
                //cmd.Parameters.AddWithValue("@ModelId", car.ModelId);
                cmd.Parameters.AddWithValue("@ImageFileName", car.ImageFileName);

                cn.Open();

                cmd.ExecuteNonQuery();

                car.CarId = (int)param.Value;
            }
        }

            public void Update(Car car)
        {
            using (var cn = new SqlConnection(Settings.GetConnectionString()))
            {
                SqlCommand cmd = new SqlCommand("CarUpdate", cn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@CarId", car.CarId);
                cmd.Parameters.AddWithValue("@Body", car.Body);
                cmd.Parameters.AddWithValue("@Year", car.Year);
                cmd.Parameters.AddWithValue("@ExColor", car.ExColor);
                cmd.Parameters.AddWithValue("@IntColor", car.IntColor);
                cmd.Parameters.AddWithValue("@Transmission", car.Transmission);
                cmd.Parameters.AddWithValue("@Type", car.Type);
                cmd.Parameters.AddWithValue("@MSRP", car.MSRP);
                cmd.Parameters.AddWithValue("@Price", car.Price);
                //cmd.Parameters.AddWithValue("@MakeId", car.MakeId);
                //cmd.Parameters.AddWithValue("@ModelId", car.ModelId);
                cmd.Parameters.AddWithValue("@ImageFileName", car.ImageFileName);

                cn.Open();

                cmd.ExecuteNonQuery();
            }
        }

        //public Car Search(string type, string term, decimal minPrice, decimal maxPrice, int minYear, int maxYear)
        //{
        //    IEnumerable<Car> cars = new List<Car>();
        //    switch (type)
        //    {
        //        case "new":
        //            cars = GetAll().Where(v => v.Type == "New");
        //            break;
        //        case "used":
        //            cars = GetAll().Where(v => v.Type == "Used");
        //            break;
        //        case "all":
        //            cars = GetAll();
        //            break;
        //        default:
        //            break;
        //    }
        //    List<Car> found = new List<Car>();
        //    int year = 0;
        //    int.TryParse(term, out year);

        //    foreach (var car in cars)
        //    {
        //        car.Make = makeRepo.GetById(car.MakeId);
        //        car.Model = modelRepo.GetById(car.ModelId);

        //        if (car.Year >= minYear && car.Year <= maxYear && car.Price >= minPrice && car.Price <= maxPrice)
        //        {
        //            if (term != "hamster")
        //            {
        //                if (car.Year == year || car.Make.MakeName.ToLower().Contains(term.ToLower()) || car.Model.ModelName.ToLower().Contains(term.ToLower()))
        //                {
        //                    found.Add(car);
        //                }
        //            }
        //            else
        //            {
        //                found.Add(car);
        //            }
        //        }
        //    }

        //    cars = found;
        //    return cars;
        //}

        //public IEnumerable<CarViewModel> GetNewCarsSorted(string searchText = "", decimal minPrice = 0, decimal maxPrice = 900000000, int minYear = 0, int maxYear = 2500)
        //{
        //    List<CarViewModel> cars = new List<CarViewModel>();
        //    using (SqlConnection conn = new SqlConnection())
        //    {
        //        conn.ConnectionString = _connection;

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.Connection = conn;
        //        cmd.CommandText = "GetNewCarsSorted";
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@SearchText", searchText);
        //        cmd.Parameters.AddWithValue("@MinPrice", minPrice);
        //        cmd.Parameters.AddWithValue("@MaxPrice", maxPrice);
        //        cmd.Parameters.AddWithValue("@MinYear", minYear);
        //        cmd.Parameters.AddWithValue("@MaxYear", maxYear);

        //        conn.Open();
        //        using (SqlDataReader dr = cmd.ExecuteReader())
        //        {
        //            while (dr.Read())
        //            {
        //                CarViewModel current = new CarViewModel();

        //                current.CarId = (int)dr["CarId"];
        //                current.Year = (int)dr["Year"];
        //                current.Type = dr["Type"].ToString();
        //                current.Style = dr["Style"].ToString();
        //                current.Transmission = dr["Trans"].ToString();
        //                current.ExteriorColor = dr["Color"].ToString();
        //                current.Interior = dr["Interior"].ToString();
        //                current.Mileage = (int)dr["Mileage"];
        //                current.Price = (decimal)dr["SalePrice"];
        //                current.MSRP = (decimal)dr["MSRP"];
        //                current.Sold = (bool)dr["Sold"];
        //                current.Description = dr["Description"].ToString();
        //                current.Make = dr["MakeName"].ToString();
        //                current.Model = dr["ModelName"].ToString();

        //                cars.Add(current);
        //            }
        //        }
        //    }

        //    return cars;
        //}
    }
}
