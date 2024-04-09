using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SqlConn
{
    class DatabaseConnection
    {
        public static void TestDatabaseConnection()
        {
            string connection = "Server=localhost,1433;Database=Mos_Drones;User Id=sa;Password=password123;";

            SqlConnection conn = new SqlConnection(connection);
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

        }
        static void Main(string[] args)
        {
            TestDatabaseConnection();
        }
    }
}
