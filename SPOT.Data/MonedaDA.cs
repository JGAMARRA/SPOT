using SPOT.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SPOT.Data
{
    public class MonedaDA
    {

        public List<MonedaBE> getAllMoneda()
        {
            List<MonedaBE> listResponse = null;

            using (var sqlcontext = new SqlConnection("Data Source =.; Initial Catalog = SPOT; User Id = sa; Password = 123456"))
            {
                try
                {
                    sqlcontext.Open();
                    SqlCommand command = new SqlCommand();
                    command.Connection = sqlcontext;
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "dbo.usp_Moneda_GetAll";

                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        listResponse = new List<MonedaBE>();
                        while (reader.Read())
                        {
                            listResponse.Add(new MonedaBE()
                            {
                                idMoneda = Convert.ToInt32(reader["IdMoneda"].ToString()),
                                descripcion = reader["Descripcion"].ToString()                                                                
                            });
                        }
                    }
                    reader.Close();

                }
                catch
                {
                    sqlcontext.Close();
                }
                finally
                {
                    sqlcontext.Close();
                }

            }
            return listResponse;
        }

    }
}



