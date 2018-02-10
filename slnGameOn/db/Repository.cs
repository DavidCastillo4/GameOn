//  --------------------------------------------------------------------------------------
// slnGameOn.Repository.cs
// 2018/02/09
//  --------------------------------------------------------------------------------------

using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace slnGameOn.db
{
    public class Repository
    {
        readonly string connectionString = WebConfigurationManager.ConnectionStrings["cnSql"].ConnectionString;

        public DataSet ReturnDataSet(string query)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    using (var dataAdapter = new SqlDataAdapter(command))
                    {
                        try
                        {
                            var data = new DataSet();
                            connection.Open();
                            dataAdapter.Fill(data);
                            return data;
                        }
                        finally
                        {
                            connection.Close();
                        }
                    }
                }
            }
        }
    }
}