using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Managers.Models;
using Accessors.Accessors;

namespace UnitTests
{
    [TestClass]
    public class AddressAccessorTests
    {
        [TestMethod]
        public void Load_All_Addresses_From_Db()
        {
            List<Address> addressList = new List<Address>();
        }

        [TestMethod]
        public void Load_One_Address_From_Db_Using_Id()
        {
            Address a = null;
        }
    }
}
