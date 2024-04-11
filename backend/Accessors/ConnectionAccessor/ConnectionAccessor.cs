using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;

namespace Accessors
{
    class ConnectionAccessor
    {
        public static void TestDatabaseConnection()
        {
            string connection = "Data Source=ANGIE-DELL-XPS\\SQLEXPRESS01; Initial Catalog=mos_drones; Integrated Security=True; MultipleActiveResultSets=True;";
            // string connection = "Server = localhost,1433; Database = Mos_Drones; User Id = sa; Password = YourStrong!Passw0rd;";

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
