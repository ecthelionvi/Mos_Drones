using System.Data.SqlClient;
using Accessors.ConnectionAccessor;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetConnectionAccessorTest
    {
        [TestMethod]
        public void ValidGetConnection_ReturnsValidSqlConnection()
        {
            string expectedConnectionString = "Data Source=ANGIE-DELL-XPS\\SQLEXPRESS01; Initial Catalog=mos_drones; Integrated Security=True; MultipleActiveResultSets=True;";

            SqlConnection connection = ConnectionAccessor.GetConnection();
            string actualConnectionString = connection.ConnectionString;

            Assert.IsNotNull(connection);
            Assert.AreEqual(expectedConnectionString, actualConnectionString);
        }
    }
}
