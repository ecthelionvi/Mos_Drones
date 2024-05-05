using Accessors.DBModels;
using Engines.BizLogic;

namespace UnitTests.EngineTests
{
    [TestClass]
    public class ValidPasswordStrengthTests
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
            // No digit
            Assert.AreEqual(false, AccountEngine.ValidPasswordStrength("abcdefghijklmnopqrstuvwxyzABCDEF"));
            Assert.AreEqual(false, AccountEngine.ValidPasswordStrength("ImyNameIsTom"));
            // Not long enough
            Assert.AreEqual(false, AccountEngine.ValidPasswordStrength("L697"));
            // No uppercase letter
            Assert.AreEqual(false, AccountEngine.ValidPasswordStrength("password123"));
            // No lowercase letter
            Assert.AreEqual(false, AccountEngine.ValidPasswordStrength("PASSWORD123"));
        }
    }

    [TestClass]
    public class ValidSignUpTests
    {
        [TestMethod]
        public void ValidSignUp()
        {
            Assert.AreEqual(true, AccountEngine.ValidateSignUp("random123@gmail.com", "Password123"));
        }

        [TestMethod]
        public void InvalidSignUp_WithExistingEmail()
        {

            Assert.AreEqual(false, AccountEngine.ValidateSignUp("blillie1@imdb.com", "Password123"));
        }

        [TestMethod]
        public void InvalidSignUp_WithInvalidPassword()
        {
            Assert.AreEqual(false, AccountEngine.ValidateSignUp("random123@gmail.com", "password123"));
        }
    }

    [TestClass]
    public class ValidateLoginTests
    {
        [TestMethod]
        public void ValidLogin()
        {
            Coordinate coord = new Coordinate(40.81338, -96.65949);
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord);
            AccountDataModel account = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);
            Assert.AreEqual(true, AccountEngine.ValidateLogin(account, "uI7lq}{e0WU"));
        }

        [TestMethod]
        public void InvalidLogin()
        {
            Coordinate coord = new Coordinate(40.81338, -96.65949);
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord);
            AccountDataModel account = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);
            Assert.AreEqual(false, AccountEngine.ValidateLogin(account, "uI7lq}{e0WU!"));
        }
    }
}
