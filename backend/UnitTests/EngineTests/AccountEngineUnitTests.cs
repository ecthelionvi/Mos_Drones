using Accessors.Account.Models;
using Accessors.Address.Models;
using Engines.BizLogic;
using Engines.BizLogic.Login;

namespace UnitTests.EngineTests
{
    [TestClass]
    public class ValidateLoginTests
    {
        [TestMethod]
        public void ValidLogin()
        {
            LoginEngine loginEngine = new LoginEngine();
            
            Coordinate coord = new Coordinate(40.81338, -96.65949);
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord);
            AccountDataModel account = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);
            Assert.AreEqual(true, loginEngine.ValidateLogin(account, "uI7lq}{e0WU"));
        }

        [TestMethod]
        public void InvalidLogin()
        {
            LoginEngine loginEngine = new LoginEngine();
            
            Coordinate coord = new Coordinate(40.81338, -96.65949);
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street", coord);
            AccountDataModel account = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);
            Assert.AreEqual(false, loginEngine.ValidateLogin(account, "uI7lq}{e0WU!"));
        }
    }
}
