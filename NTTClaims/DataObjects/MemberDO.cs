using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NTTClaims.DataObjects
{
    public class MemberDO
    {
        private IConfiguration _config;
        private SqlConnection connection;
        private string connectionString;

        public MemberDO(IConfiguration config)
        {
            _config = config;
            connectionString = _config.GetConnectionString("NTTHealthService");
        }

        //Member by ID
        public DataTable GetMemberbyID(int memberID, DataTable dt)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "usp_GetMemberByID";
                        command.Parameters.AddWithValue("@MemberID", memberID);
                        command.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        adapter.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                //write log information
                Console.Write(ex.Message);
            }
            finally
            {
                dt.Dispose();
                connection.Dispose();
            }
            return dt;
        }
                
    }
}
