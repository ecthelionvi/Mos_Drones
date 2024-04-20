using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Accessors.Accessors;
using Accessors.DBModels;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetAccountWithAccountIdAccessorTest
    {
        [TestMethod]
        public void ValidGetAccountWithAccountId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(true, GetAccountWithAccountId(1));
            //Assert.AreEqual(true, GetAccountWithAccountId(2));
            //Assert.AreEqual(true, GetAccountWithAccountId(3));
        }

        [TestMethod]
        public void InvalidGetAccountWithAccountId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, GetAccountWithAccountId(-1));
            //Assert.AreEqual(false, GetAccountWithAccountId(-2));
            //Assert.AreEqual(false, GetAccountWithAccountId(-3));
        }

        [TestMethod]
        public void NullGetAccountWithAccountId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, GetAccountWithAccountId());
            //Assert.AreEqual(false, GetAccountWithAccountId());
            //Assert.AreEqual(false, GetAccountWithAccountId());
        }
    }

    [TestClass]
    public class GetAccountWithEmailAccessorTest
    {
        [TestMethod]
        public void ValidGetAccountWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(true, GetAccountWithEmail("123456@gmail.com"));
            //Assert.AreEqual(true, GetAccountWithEmail("ThisIsATest@gmail.com"));
            //Assert.AreEqual(true, GetAccountWithEmail("WhatAnEmail@gmail.com"));
        }

        [TestMethod]
        public void InvalidGetAccountWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, GetAccountWithEmail("NOTInDataBase@gmail.com"));
            //Assert.AreEqual(false, GetAccountWithEmail("IDkThisIsABadTest@gmail.com"));
            //Assert.AreEqual(false, GetAccountWithEmail("ThridTimesCharm@gmail.com"));
        }

        [TestMethod]
        public void NullGetAccountWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, GetAccountWithEmail());
            //Assert.AreEqual(false, GetAccountWithEmail());
            //Assert.AreEqual(false, GetAccountWithEmail());
        }     
    }
}
