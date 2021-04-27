using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace NTTClaims.DataObjects
{
    public class ClaimsDO
    {
        private IConfiguration _config;
        private SqlConnection connection;
        private string connectionString;

        public ClaimsDO(IConfiguration config)
        {
            _config = config;
            connectionString = _config.GetConnectionString("NTTHealthService");
        }
        //Claim by ID
        public DataTable GetClaimbyID(int memberID, DataTable dt)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "usp_GetClaimByID";
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

        //All Claims
        public DataTable GetAllClaimsDetails(DataTable dt)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "usp_GetAllClaimDetails";
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

        //All Claims by Date
        public DataTable GetClaimsDetailsByDate(DataTable dt, DateTime date)
        {
            try
            {
                using (connection = new SqlConnection(connectionString))
                {
                    using (var command = new SqlCommand())
                    {
                        command.Connection = connection;
                        command.CommandText = "usp_GetClaimDetailsByDate";
                        command.Parameters.AddWithValue("@claimeddate", date);
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
