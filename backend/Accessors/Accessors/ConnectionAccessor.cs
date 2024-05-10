using System.Data.SqlClient;

namespace Accessors.ConnectionAccessor
{
    public class ConnectionAccessor
    {
        public static SqlConnection GetConnection()
        {
            string connString = "Server=localhost,1433;Database=master;User Id=SA;Password=MyStrongPassword123;Integrated Security=False;;";
            //string connString = "Data Source=ANGIE-DELL-XPS\\SQLEXPRESS01; Initial Catalog=mos_drones; Integrated Security=True; MultipleActiveResultSets=True;";
            SqlConnection connection = new SqlConnection(connString);
            return connection;
        }

    }
}

