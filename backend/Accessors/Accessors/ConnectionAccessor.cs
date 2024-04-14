using System.Data.SqlClient;
using Accessors.Accessors;
using Managers.Models;

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
            List<Address> addressList = AddressAccessor.GetAddressList();
            Console.WriteLine("All Addresses: ");
            foreach (Address address in addressList)
            {
                Console.WriteLine(address);
            }

            Console.WriteLine("The address with addressId of 1: ");
            Address address1 = AddressAccessor.GetAddress(1);
            Console.WriteLine(address1);

            Account account = AccountAccessor.GetAccountWithEmail("avanarsdall0@cocolog-nifty.com");
            Console.WriteLine("The account with email avanarsdall0@cocolog-nifty.com:");
            Console.WriteLine(account);

            Console.ReadLine();
        }
    }
}
