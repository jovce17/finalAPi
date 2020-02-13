using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace MF.Domain.Service.SP
{
    public class testSP
    {
        private SqlConnection connection;

        public static IConfiguration Configuration { get; set; }
        public string ConnectionString { get; set; }

        public async Task<List<string>> GetBlogSummaries()
        {
            ConnectionString = "Data Source=DESKTOP-HGLV3CG;Initial Catalog=Tanja2;Integrated Security=True;MultipleActiveResultSets=true;";

            List<string> headers = new List<string>();
            using ( connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.test_sp"))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Connection = connection;

                    connection.Open();

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            headers.Add(reader[0].ToString());
                        }
                    }

                    reader.Close();
                    connection.Close();
                }
            }

            return headers;
        }
        public async Task<int> DoStaff(int y)
        {
            ConnectionString = "Data Source=DESKTOP-HGLV3CG;Initial Catalog=Tanja2;Integrated Security=True;MultipleActiveResultSets=true;";

            int x=0;
            using (connection = new SqlConnection(ConnectionString))
            {
                using (SqlCommand command = new SqlCommand("dbo.test2_sp " ))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.Add("@x", SqlDbType.VarChar).Value = y.ToString();
                    command.Connection = connection;

                    connection.Open();

                    SqlDataReader reader = await command.ExecuteReaderAsync();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            Int32.TryParse(reader[0].ToString(), out x);
                        }
                    }                
                   
                    reader.Close();
                    connection.Close();
                }
            }

            return x;
        }














    }
}
