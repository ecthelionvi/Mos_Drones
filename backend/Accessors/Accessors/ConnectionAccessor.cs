using System.Data.SqlClient;
using Accessors.Accessors;
using Accessors.DBModels;

namespace Accessors.ConnectionAccessor
{
    public class ConnectionAccessor
    {
        //public static void TestDatabaseConnection()
        //{
        //    SqlConnection conn = GetConnection();
        //    Console.WriteLine("Getting Connection ...");
        //    try
        //    {
        //        Console.WriteLine("Opening Connection ...");
        //        conn.Open();
        //        Console.WriteLine("Connection successful!");
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Error: " + e.Message);
        //    }
        //    Console.Read();
        //    conn.Close();
        //    Console.WriteLine("Connection closed");

        //}

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
            OrderDataModel order = OrderAccessor.GetOrderWithOrderId(3);
            Console.WriteLine("The order with orderId of 3 is:");
            Console.WriteLine(order);

            OrderDataModel o = OrderAccessor.GetOrderWithPackageId("4829170638572946");
            Console.WriteLine("The order with Package Id of 4829170638572946 is:");
            Console.WriteLine(o);

            //List<OrderDataModel> orderList = OrderAccessor.GetOrderListWithEmail("avanarsdall0@cocolog-nifty.com");
            //Console.WriteLine("All Orders for email avanarsdall0@cocolog-nifty.com:");
            //foreach (OrderDataModel or in orderList)
            //{
            //    Console.WriteLine(or);
            //}

            // Testing DepotAccessor methods
            DepotDataModel depot = DepotAccessor.GetDepotWithDepotId(1);
            Console.WriteLine("The depot with depotId of 1 is:");
            Console.WriteLine(depot);

            List<DepotDataModel> depotList = DepotAccessor.GetDepotList();
            Console.WriteLine("All Depots:");
            foreach (DepotDataModel d in depotList)
            {
                Console.WriteLine(d);
            }

            // Testing DroneAccessor methods
            DroneDataModel drone = DroneAccessor.GetDrone(2);
            Console.WriteLine("The drone with droneId of 2 is:");
            Console.WriteLine(drone);

            List<DroneDataModel> droneList = DroneAccessor.GetDroneList();
            Console.WriteLine("All Drones: ");
            foreach (DroneDataModel d in droneList)
            {
                Console.WriteLine(d);
            }

            // Inserting into the database
            int addressId = AddressAccessor.InsertAddress("Pleasant Dale", "Nebraska", "68423", "2468 North 10th Road", 40.828410, -96.929760);
            Console.WriteLine("The addressId of the selected/inserted address is " + addressId + "\n");

            int accountId = AccountAccessor.InsertAccount("Angie", "Zheng", "azheng2@huskers.unl.edu", "password123", "Lincoln", "Nebraska", "68588", "1400 R St", 40.817638, -96.699997, false);
            Console.WriteLine("The accountId of the selected/inserted account is " + accountId + "\n");

            int accountId2 = AccountAccessor.InsertAccount("Angie", "Zheng", "angizheng4201@gmail.com", "password123", "Lincoln", "Nebraska", "68588", "1400 R St", 40.817638, -96.699997, false);
            Console.WriteLine("The accountId of the selected/inserted account is " + accountId2 + "\n");

            DateTime deliveryDate = new DateTime(2024, 4, 23, 17, 02, 00);
            DateTime shipDate = DateTime.Now;
            Coordinate c1 = new Coordinate(40.817638, -96.699997);
            AddressDataModel shippedFrom = new AddressDataModel(null, "Lincoln", "Nebraska", "68588", "1400 R St", c1);
            Coordinate c2 = new Coordinate(40.828410, -96.929760);
            AddressDataModel shippedTo = new AddressDataModel(null, "Pleasant Dale", "Nebraska", "68423", "2468 North 10th Road", c2);
            OrderDataModel order2 = new OrderDataModel(null, null, shipDate, deliveryDate, 1, shippedFrom, shippedTo);
            int orderId = OrderAccessor.InsertOrder(order2);
            Console.WriteLine("The orderId of the inserted Order is " + orderId);

            Console.ReadLine();
        }
    }
}
