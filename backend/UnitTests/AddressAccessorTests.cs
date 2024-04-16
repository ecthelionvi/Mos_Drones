using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accessors.DBModels;
using Accessors.Accessors;

namespace UnitTests
{
    [TestClass]
    public class AddressAccessorTests
    {
        [TestMethod]
        public void Load_All_Addresses_From_Db()
        {
            List<AddressDataModel> addressList = new List<AddressDataModel>();
        }

        [TestMethod]
        public void Load_One_Address_From_Db_Using_Id()
        {
            AddressDataModel a = null;
        }
    }
}
