using Accessors.Accessors;
using Accessors.DBModels;
using Engines.BizLogic;
using Managers.Helpers;
using Managers.Models;

namespace Managers;

public class AccountManager
{

    public static void addAccount(Account userAccount)
    {
        
    }
    public static Account? ValidateLogin(string username, string password)
    {
        bool isValid = false;
        AccountDataModel? accountDataModel = AccountAccessor.GetAccountWithEmail(username);

        if (accountDataModel != null)
        {
            isValid = AccountEngine.ValidateLogin(accountDataModel, password);
            
        }
        
        return isValid == true ? AccountHelper.AccountDataModelToAccount(accountDataModel!) : null;
    }
}