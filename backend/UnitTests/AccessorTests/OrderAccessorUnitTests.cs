using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accessors.DBModels;
using Accessors.Accessors;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetOrderWithOrderIdAccessorTest
    {
        [TestMethod]
        public void ValidGetOrderWithOrderId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(order, GetOrderWithOrderId(1));
            //Assert.AreEqual(order, GetOrderWithOrderId(2));
            //Assert.AreEqual(order, GetOrderWithOrderId(3));
        }

        [TestMethod]
        public void InvalidGetOrderWithOrderId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, GetOrderWithOrderId(-1));
            //Assert.AreEqual(NULL, GetOrderWithOrderId(-2));
            //Assert.AreEqual(NULL, GetOrderWithOrderId(-3));
        }

        [TestMethod]
        public void NullGetOrderWithOrderId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, GetOrderWithOrderId(1));
            //Assert.AreEqual(NULL, GetOrderWithOrderId(2));
            //Assert.AreEqual(NULL, GetOrderWithOrderId(3));
        }
    }

    [TestClass]
    public class GetOrderWithPackageIdAccessorTest
    {
        [TestMethod]
        public void ValidGetOrderWithPackageId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(order, GetOrderWithPackageId(1));
            //Assert.AreEqual(order, GetOrderWithPackageId(2));
            //Assert.AreEqual(order, GetOrderWithPackageId(3));
        }

        [TestMethod]
        public void InvalidGetOrderWithPackageId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, GetOrderWithPackageId(-1));
            //Assert.AreEqual(Null, GetOrderWithPackageId(-2));
            //Assert.AreEqual(NULL, GetOrderWithPackageId(-3));
        }

        [TestMethod]
        public void NullGetOrderWithPackageId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, GetOrderWithPackageId(NULL));
            //Assert.AreEqual(NULL, GetOrderWithPackageId(NULL));
            //Assert.AreEqual(NULL, GetOrderWithPackageId(NULL));
        }
    }

    [TestClass]
    public class GetOrderListWithEmailAccessorTest
    {
        [TestMethod]
        public void ValidGetOrderListWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(orderList, GetOrderListWithEmail("123456@gmail.com"));
            //Assert.AreEqual(orderList, GetOrderListWithEmail("ThisIsATest@gmail.com"));
            //Assert.AreEqual(orderList, GetOrderListWithEmail("WhatAnEmail@gmail.com"));
        }

        [TestMethod]
        public void InvalidGetOrderListWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(!orderList, GetOrderListWithEmail("NOTInDataBase@gmail.com"));
            //Assert.AreEqual(!orderList, GetOrderListWithEmail("IDkThisIsABadTest@gmail.com"));
            //Assert.AreEqual(!orderList, GetOrderListWithEmail("ThridTimesCharm@gmail.com"));
        }

        [TestMethod]
        public void NullGetOrderListWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, GetOrderListWithEmail(NULL));
            //Assert.AreEqual(NULL, GetOrderListWithEmail(NULL));
            //Assert.AreEqual(NULL, GetOrderListWithEmail(NULL));
        }
    }
}
