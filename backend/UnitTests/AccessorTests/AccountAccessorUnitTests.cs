using Accessors.Accessors;
using Accessors.DBModels;

namespace UnitTests.AccessorTests
{
    [TestClass]
    public class GetAccountWithAccountIdAccessorTests
    {
        [TestMethod]
        public void ValidGetAccountWithAccountId()
        {
            AddressDataModel accountAddress = new AddressDataModel(1, "Lincoln", "Nebraska", "68510", "4321 O Street");
            AccountDataModel expectedAccount = new AccountDataModel(1, "Alfred", "Van Arsdall", "avanarsdall0@cocolog-nifty.com", "uI7lq}{e0WU", accountAddress, true);

            AccountDataModel actualAccount = AccountAccessor.GetAccountWithAccountId(1);
            Assert.AreEqual(expectedAccount, actualAccount);
        }

        [TestMethod]
        public void InvalidGetAccountWithAccountId()
        {
            AccountDataModel account = AccountAccessor.GetAccountWithAccountId(-1);
            Assert.IsNull(account);
        }
    }

    [TestClass]
    public class GetAccountWithEmailAccessorTests
    {
        [TestMethod]
        public void ValidGetAccountWithEmail()
        {
            AddressDataModel accountAddress = new AddressDataModel(2, "Lincoln", "Nebraska", "68521", "2468 North 27th Street");
            AccountDataModel expectedAccount = new AccountDataModel(2, "Beltran", "Lillie", "blillie1@imdb.com", "hC7S>lx+N7a(?2>k", accountAddress, false);

            AccountDataModel actualAccount = AccountAccessor.GetAccountWithEmail("blillie1@imdb.com");
            Assert.AreEqual(expectedAccount, actualAccount);
        }

        [TestMethod]
        public void InvalidGetAccountWithEmail()
        {
            AccountDataModel invalidAccount = AccountAccessor.GetAccountWithEmail("random_email123@example.com");
            Assert.IsNull(invalidAccount);
        }

        [TestMethod]
        public void NullGetAccountWithEmail()
        {
            AccountDataModel accountWithNullEmail = AccountAccessor.GetAccountWithEmail(null);
            Assert.IsNull(accountWithNullEmail);
        }
    }

    [TestClass]
    public class InsertAccountTests
    {
        [TestMethod]
        public void ValidInsertAccount()
        {
            int expectedAccountId = 3;

            int actualAccountId = AccountAccessor.InsertAccount("Angie", "Zheng", "azheng2@huskers.unl.edu", "password123", "Lincoln", "Nebraska", "68588", "1400 R St", false);
            Assert.AreEqual(expectedAccountId, actualAccountId);
        }
    }
}
