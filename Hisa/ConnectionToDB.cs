using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hisa
{
    class ConnectionToDB
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection connection = null;

            try
            {
                connection = new SqlConnection();

                connection.ConnectionString = @"Data Source=ADMIN-PC\SQLEXPRESS; Initial Catalog=Hisa; Integrated Security=False;User ID=sa;Password=Kasarani17b;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

                return connection;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
