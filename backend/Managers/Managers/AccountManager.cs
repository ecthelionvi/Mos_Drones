using Accessors.Accessors;
using Accessors.DBModels;
using Engines.BizLogic;
using Managers.Helpers;
using Managers.Models;

namespace Managers;

public class AccountManager
{
    public static void AddAccount(Account account)
    {
        //AccountAccessor.InsertAccount(account.FirstName, account.LastName, account.Email, account.Password, account.AccountAddress.City, account.AccountAddress.State, account.AccountAddress.ZipCode, account.AccountAddress.AddressLine, false);
    }
    public static Account? ValidateLogin(string email, string password)
    {
        bool isValid = false;
        AccountDataModel accountDataModel = AccountAccessor.GetAccountWithEmail(email);

        if (accountDataModel != null)
        {
            isValid = AccountEngine.ValidateLogin(accountDataModel, password);
        }
        
        return isValid == true ? AccountHelper.AccountDataModelToAccount(accountDataModel!) : null;
    }
}