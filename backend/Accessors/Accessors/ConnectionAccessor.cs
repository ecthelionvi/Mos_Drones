using System.Data.SqlClient;
using Accessors.Accessors;
using Accessors.DBModels;

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
            // Testing AddressAccessor methods
            List<AddressDataModel> addressList = AddressAccessor.GetAddressList();
            Console.WriteLine("All Addresses: ");
            foreach (AddressDataModel address in addressList)
            {
                Console.WriteLine(address);
            }

            Console.WriteLine("The address with addressId of 1: ");
            AddressDataModel address1 = AddressAccessor.GetAddress(1);
            Console.WriteLine(address1);

            // Testing AccountAccessor methods
            AccountDataModel account = AccountAccessor.GetAccountWithEmail("avanarsdall0@cocolog-nifty.com");
            Console.WriteLine("The account with email avanarsdall0@cocolog-nifty.com:");
            Console.WriteLine(account);

            // Testing OrderAccessor methods
            OrderDataModel order = OrderAccessor.GetOrderWithOrderId(60);
            Console.WriteLine("The order with orderId of 60 is:");
            Console.WriteLine(order);

            OrderDataModel o = OrderAccessor.GetOrderWithPackageId("4829170638572946");
            Console.WriteLine("The order with Package Id of 4829170638572946 is:");
            Console.WriteLine(o);

            List<OrderDataModel> orderList = OrderAccessor.GetOrderListWithEmail("avanarsdall0@cocolog-nifty.com");
            Console.WriteLine("All Orders for email avanarsdall0@cocolog-nifty.com:");
            foreach (OrderDataModel or in orderList)
            {
                Console.WriteLine(or);
            }
            
            // Testing DepotAccessor methods
            DepotDataModel depot = DepotAccessor.GetDepotWithDepotId(80);
            Console.WriteLine("The depot with depotId of 80 is:");
            Console.WriteLine(depot);

            // Testing DroneAccessor methods
            DroneDataModel drone = DroneAccessor.GetDrone(101);
            Console.WriteLine("The drone with droneId of 101 is:");
            Console.WriteLine(drone);

            List<DroneDataModel> droneList = DroneAccessor.GetDroneList();
            Console.WriteLine("All Drones: ");
            foreach (DroneDataModel d in droneList)
            {
                Console.WriteLine(d);
            }        
            
            Console.ReadLine();
        }
    }
}
