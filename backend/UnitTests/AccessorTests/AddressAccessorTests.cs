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
        public void LoadAllAddressesFromDb()
        {
            List<Address> addressList = new List<Address>();
        }

        [TestMethod]
        public void LoadOneAddressFromDbUsingId()
        {
            Address a = null;
        }
    }
}
