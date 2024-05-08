using Accessors.Accessors;
using Accessors.DBModels;
using Engines.BizLogic;
using Managers.Helpers;
using Managers.Models;

namespace Managers;

public class AccountManager
{
    public static int AddAccount(Account account)
    {
        int accountId = -1;
        if (AccountEngine.ValidateSignUp(account.Email, account.Password))
        {
            AccountAccessor accountAccessor = new AccountAccessor(); 
            accountId = accountAccessor.InsertAccount(AccountHelper.AccountToAccountDataModel(account)).Result;
        };
        return accountId;
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