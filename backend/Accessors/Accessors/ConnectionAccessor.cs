using System.Data.SqlClient;

namespace Accessors.ConnectionAccessor
{
    class ConnectionAccessor
    {
        public static void TestDatabaseConnection()
        {
            SqlConnection conn = GetConnection();
            Console.WriteLine("Getting Connection ...");
            try
            {
                Console.WriteLine("Opening Connection ...");
                conn.Open();
                Console.WriteLine("Connection successful!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }
            Console.Read();
            conn.Close();
            Console.WriteLine("Connection closed");

        }

        public static SqlConnection GetConnection()
        {
            string connString = "Data Source=ANGIE-DELL-XPS\\SQLEXPRESS01; Initial Catalog=mos_drones; Integrated Security=True; MultipleActiveResultSets=True;";
            SqlConnection connection = new SqlConnection(connString);
            return connection;
        }

        static void Main(string[] args)
        {
            TestDatabaseConnection();
        }
    }
}
