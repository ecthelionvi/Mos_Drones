using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Managers.Models;
using Accessors.Accessors;

namespace backend{
    [TestFixture]
    public class GetOrderWithOrderIdAccessorTest
    {
        [Test]
        public void ValidGetOrderWithOrderId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(order, GetOrderWithOrderId(1));
            //Assert.AreEqual(order, GetOrderWithOrderId(2));
            //Assert.AreEqual(order, GetOrderWithOrderId(3));

        [Test]
        public void InvalidGetOrderWithOrderId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, GetOrderWithOrderId(-1));
            //Assert.AreEqual(NULL, GetOrderWithOrderId(-2));
            //Assert.AreEqual(NULL, GetOrderWithOrderId(-3));
        }
        public void NullGetOrderWithOrderId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, GetOrderWithOrderId(1));
            //Assert.AreEqual(NULL, GetOrderWithOrderId(2));
            //Assert.AreEqual(NULL, GetOrderWithOrderId(3));
        }
    }
    [TestFixture]
    public class GetOrderWithPackageIdAccessorTest
    {
        [Test]
        public void ValidGetOrderWithPackageId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(order, GetOrderWithPackageId(1));
            //Assert.AreEqual(order, GetOrderWithPackageId(2));
            //Assert.AreEqual(order, GetOrderWithPackageId(3));

        [Test]
        public void InvalidGetOrderWithPackageId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, GetOrderWithPackageId(-1));
            //Assert.AreEqual(Null, GetOrderWithPackageId(-2));
            //Assert.AreEqual(NULL, GetOrderWithPackageId(-3));
        }
        public void NullGetOrderWithPackageId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, GetOrderWithPackageId(NULL));
            //Assert.AreEqual(NULL, GetOrderWithPackageId(NULL));
            //Assert.AreEqual(NULL, GetOrderWithPackageId(NULL));
        }
    }
    [TestFixture]
    public class GetOrderListWithEmailAccessorTest
    {
        [Test]
        public void ValidGetOrderListWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(orderList, GetOrderListWithEmail("123456@gmail.com"));
            //Assert.AreEqual(orderList, GetOrderListWithEmail("ThisIsATest@gmail.com"));
            //Assert.AreEqual(orderList, GetOrderListWithEmail("WhatAnEmail@gmail.com"));

        [Test]
        public void InvalidGetOrderListWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(!orderList, GetOrderListWithEmail("NOTInDataBase@gmail.com"));
            //Assert.AreEqual(!orderList, GetOrderListWithEmail("IDkThisIsABadTest@gmail.com"));
            //Assert.AreEqual(!orderList, GetOrderListWithEmail("ThridTimesCharm@gmail.com"));
        }
        public void NullGetOrderListWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(NULL, GetOrderListWithEmail(NULL));
            //Assert.AreEqual(NULL, GetOrderListWithEmail(NULL));
            //Assert.AreEqual(NULL, GetOrderListWithEmail(NULL));
        }
    }
}