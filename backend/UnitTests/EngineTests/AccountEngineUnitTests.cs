using Accessors.DBModels;
using Engines.BizLogic;

namespace UnitTests.EngineTests
{
    [TestClass]
    public class ValidSignUpTests
    {
        [TestMethod]
        public void ValidSignUp()
        {
            Assert.AreEqual(true, LoginEngine.ValidateSignUp("random123@gmail.com", "Password123"));
        }

        [TestMethod]
        public void InvalidSignUp_WithExistingEmail()
        {

            Assert.AreEqual(false, LoginEngine.ValidateSignUp("blillie1@imdb.com", "Password123"));
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
            Assert.AreEqual(true, LoginEngine.ValidateLogin(account, "uI7lq}{e0WU"));
        }

        [TestMethod]
        public void InvalidLogin()
        {
            Coordinate coord = new Coordinate(40.81338, -96.65949);
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord);
            AccountDataModel account = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);
            Assert.AreEqual(false, LoginEngine.ValidateLogin(account, "uI7lq}{e0WU!"));
        }
    }
}
