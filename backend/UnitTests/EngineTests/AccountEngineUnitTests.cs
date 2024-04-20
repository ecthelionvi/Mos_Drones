using System;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Engines.BizLogic;

namespace UnitTests.EngineTests
{
    [TestClass]
    public class AccountPasswordEngineTest
    {
        [TestMethod]
        public void ValidPasswordStrength()
        {
            Assert.AreEqual(true, AccountEngine.ValidPasswordStrength("R@inb0w$un5h!n3"));
            Assert.AreEqual(true, AccountEngine.ValidPasswordStrength("!8G&vP#2qR!5sY@9"));
            Assert.AreEqual(true, AccountEngine.ValidPasswordStrength("S3cureP@ssw0rd!"));
        }

        [TestMethod]
        public void InvalidPasswordStrength()
        {
            Assert.AreEqual(false, AccountEngine.ValidPasswordStrength("abcdefghijklmnopqrstuvwxyzABCDEF"));
            Assert.AreEqual(false, AccountEngine.ValidPasswordStrength("ImyNameIsTom"));
            Assert.AreEqual(false, AccountEngine.ValidPasswordStrength("L697"));
        }
    }
    [TestClass]
    public class AccountSignUpEngineTest
    {
        [TestMethod]
        public void ValidSignUp()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void InvalidSignUp()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void NullSignUp()
        {
            throw new NotImplementedException();
        }
    }
    [TestClass]
    public class AccountLoginEngineTest
    {
        [TestMethod]
        public void ValidSignUp()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void InvalidSignUp()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void NullSignUp()
        {
            throw new NotImplementedException();
        }
    }
}
