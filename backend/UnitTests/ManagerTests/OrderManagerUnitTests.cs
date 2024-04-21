using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accessors.Accessors;
using Accessors.DBModels;
using Managers.Helpers;
using Managers.Models;

namespace UnitTests.ManagersTests
{
    [TestClass]
    public class FindOrderTest
    {
        [TestMethod]
        public void ValidFindOrder()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(order, OrderManager.FindOrder(orderId));
            //Assert.AreEqual(order, OrderManager.FindOrder(orderId));
            //Assert.AreEqual(order, OrderManager.FindOrder(orderId));
        }

        [TestMethod]
        public void InvalidFindOrder()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(order, OrderManager.FindOrder(1));
            //Assert.AreEqual(order, OrderManager.FindOrder(2));
            //Assert.AreEqual(order, OrderManager.FindOrder(3));
        }

        [TestMethod]
        public void NullFindOrder()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, OrderManager.FindOrder(NULL));
            //Assert.AreEqual(NULL, OrderManager.FindOrder(NULL));
            //Assert.AreEqual(NULL, OrderManager.FindOrder(NULL));
        }
    }
}