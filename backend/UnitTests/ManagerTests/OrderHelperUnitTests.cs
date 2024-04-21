using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Managers.Helpers;
using Accessors.DBModels;
using Managers.Models;

namespace UnitTests.ManagersTests
{
    [TestClass]
    public class OrderDataModelToOrderModelTest
    {
        [TestMethod]
        public void ValidOrderDataModelToOrderModel()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(Order, OrderHelper.OrderDataModelToOrderModel(oDM));
            //Assert.AreEqual(Order, OrderHelper.OrderDataModelToOrderModel(oDM));
            //Assert.AreEqual(Order, OrderHelper.OrderDataModelToOrderModel(oDM));
        }

        [TestMethod]
        public void InvalidOrderDataModelToOrderModel()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(Order, OrderHelper.OrderDataModelToOrderModel(1));
            //Assert.AreEqual(Order, OrderHelper.OrderDataModelToOrderModel(2));
            //Assert.AreEqual(Order, OrderHelper.OrderDataModelToOrderModel(3));
        }

        [TestMethod]
        public void NullOrderDataModelToOrderModel()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, OrderHelper.OrderDataModelToOrderModel(NULL));
            //Assert.AreEqual(NULL, OrderHelper.OrderDataModelToOrderModel(NULL));
            //Assert.AreEqual(NULL, OrderHelper.OrderDataModelToOrderModel(NULL));
        }
    }
    [TestClass]
    public class OrderToOrderDataModelTest
    {
        [TestMethod]
        public void ValidOrderToOrderDataModel()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(OrderDataModel, OrderHelper.OrderToOrderDataModel(order));
            //Assert.AreEqual(OrderDataModel, OrderHelper.OrderToOrderDataModel(order));
            //Assert.AreEqual(OrderDataModel, OrderHelper.OrderToOrderDataModel(order));
        }

        [TestMethod]
        public void InvalidOrderToOrderDataModel()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(OrderDataModel, OrderHelper.OrderToOrderDataModel(0));
            //Assert.AreEqual(OrderDataModel, OrderHelper.OrderToOrderDataModel(1));
            //Assert.AreEqual(OrderDataModel, OrderHelper.OrderToOrderDataModel(2));
        }

        [TestMethod]
        public void NullOrderToOrderDataModel()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, OrderHelper.OrderToOrderDataModel(NULL));
            //Assert.AreEqual(NULL, OrderHelper.OrderToOrderDataModel(NULL));
            //Assert.AreEqual(NULL, OrderHelper.OrderToOrderDataModel(NULL));
        }
    }
}