using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Managers.Models;
using Accessors.Accessors;

namespace backend{
    [TestFixture]
    public class GetAccountWithAccountIdAccessorTest
    {
        [Test]
        public void ValidGetAccountWithAccountId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(true, GetAccountWithAccountId(1));
            //Assert.AreEqual(true, GetAccountWithAccountId(2));
            //Assert.AreEqual(true, GetAccountWithAccountId(3));

        [Test]
        public void InvalidGetAccountWithAccountId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, GetAccountWithAccountId(-1));
            //Assert.AreEqual(false, GetAccountWithAccountId(-2));
            //Assert.AreEqual(false, GetAccountWithAccountId(-3));
        }
        public void NullGetAccountWithAccountId()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, GetAccountWithAccountId());
            //Assert.AreEqual(false, GetAccountWithAccountId());
            //Assert.AreEqual(false, GetAccountWithAccountId());
        }
    }
    [TestFixture]
    public class GetAccountWithEmailAccessorTest
    {
        [Test]
        public void ValidGetAccountWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(true, GetAccountWithEmail("123456@gmail.com"));
            //Assert.AreEqual(true, GetAccountWithEmail("ThisIsATest@gmail.com"));
            //Assert.AreEqual(true, GetAccountWithEmail("WhatAnEmail@gmail.com"));

        [Test]
        public void InvalidGetAccountWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, GetAccountWithEmail("NOTInDataBase@gmail.com"));
            //Assert.AreEqual(false, GetAccountWithEmail("IDkThisIsABadTest@gmail.com"));
            //Assert.AreEqual(false, GetAccountWithEmail("ThridTimesCharm@gmail.com"));
        }
        public void NullGetAccountWithEmail()
        {
            throw new NotImplementedException();
            //Assert.AreEqual(false, GetAccountWithEmail());
            //Assert.AreEqual(false, GetAccountWithEmail());
            //Assert.AreEqual(false, GetAccountWithEmail());
        }
    }
}