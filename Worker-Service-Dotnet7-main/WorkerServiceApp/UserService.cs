using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerServiceApp
{
    public class UserService : IUserService
    {
        private readonly string connectionstring;
        public UserService(IConfiguration configuration)
        {
            this.connectionstring = configuration.GetConnectionString("MyDbContext");
        }

        public string GetData()
        {
            string response=string.Empty;
            try
            {
                using (SqlConnection sql = new(this.connectionstring)) 
                {
                    SqlCommand cmd = new SqlCommand("STP_GetAll", sql);
                    cmd.CommandType = CommandType.StoredProcedure;
                    sql.Open();
                    using (var reader=cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            response = reader["RoleName"].ToString();
                        }
                    }

                
                }
                return response;
            }
            catch (Exception)
            {

                throw;
            }
            throw new NotImplementedException();
        }
    }
}
