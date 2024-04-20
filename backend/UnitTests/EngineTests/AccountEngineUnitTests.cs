using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Managers.Models;
using Engines.Engines;

namespace backend{
    [TestFixture]
    public class AccountPasswordEngineTest
    {
        [Test]
        public void ValidPasswordStrength()
        {
            Assert.AreEqual(true, ValidPasswordStrength("R@inb0w$un5h!n3"));
            Assert.AreEqual(true, ValidPasswordStrength("!8G&vP#2qR!5sY@9"));
            Assert.AreEqual(true, ValidPasswordStrength("S3cureP@ssw0rd!"));
        }

        [Test]
        public void InvalidPasswordStrength()
        {
            Assert.AreEqual(false,ValidPasswordStrength("abcdefghijklmnopqrstuvwxyzABCDEF"));
            Assert.AreEqual(false, ValidPasswordStrength("ImyNameIsTom"));
            Assert.AreEqual(false, ValidPasswordStrength("L697"));
        }
    }
    [TestFixture]
    public class AccountSignUpEngineTest
    {
        [Test]
        public void ValidSignUp()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void InvalidSignUp()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void NullSignUp()
        {
            throw new NotImplementedException();
        }
    }
    [TestFixture]
    public class AccountLoginEngineTest
    {
        [Test]
        public void ValidSignUp()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void InvalidSignUp()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void NullSignUp()
        {
            throw new NotImplementedException();
        }
    }
}
