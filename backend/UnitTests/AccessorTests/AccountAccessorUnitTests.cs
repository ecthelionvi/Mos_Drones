using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.SqlClient;
using System.Net;
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
            //Assert.AreEqual(true, AccountAccessor.GetAccountWithAccountId(1));
            //Assert.AreEqual(true, AccountAccessor.GetAccountWithAccountId(2));
            //Assert.AreEqual(true, AccountAccessor.GetAccountWithAccountId(3));
        }

        [TestMethod]
        public void InvalidGetAccountWithAccountId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithAccountId(-1));
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithAccountId(-2));
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithAccountId(-3));
        }

        [TestMethod]
        public void NullGetAccountWithAccountId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithAccountId());
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithAccountId());
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithAccountId());
        }
    }

    [TestClass]
    public class GetAccountWithEmailAccessorTest
    {
        [TestMethod]
        public void ValidGetAccountWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(true, AccountAccessor.GetAccountWithEmail("123456@gmail.com"));
            //Assert.AreEqual(true, AccountAccessor.GetAccountWithEmail("ThisIsATest@gmail.com"));
            //Assert.AreEqual(true, AccountAccessor.GetAccountWithEmail("WhatAnEmail@gmail.com"));
        }

        [TestMethod]
        public void InvalidGetAccountWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithEmail("NOTInDataBase@gmail.com"));
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithEmail("IDkThisIsABadTest@gmail.com"));
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithEmail("ThridTimesCharm@gmail.com"));
        }

        [TestMethod]
        public void NullGetAccountWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithEmail());
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithEmail());
            //Assert.AreEqual(false, AccountAccessor.GetAccountWithEmail());
        }     
    }
}
