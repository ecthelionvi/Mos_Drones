using Accessors.Account;
using Accessors.Account.Models;
using Engines.BizLogic;
using Engines.BizLogic.Login;
using Managers.Account.Helpers;

namespace Managers.Account;

public class AccountManager : IAccountManager
{
    private readonly IAccountAccessor _accountAccessor;

    public AccountManager(IAccountAccessor accountAccessor)
    {
        _accountAccessor = accountAccessor;
    }
    public string AddAccount(Models.Account account)
    {
        string message = "Email already in use.";
        
        if (_accountAccessor.GetAccountWithEmail(account.Email).AccountId == null)
        {
            if (_accountAccessor.InsertAccount(AccountHelper.AccountToAccountDataModel(account)).Result != -1)
            {
                message = "Account created successfully!";
            }
            else
            {
                message = "Error creating account.";
            }
            
        };
        return message;
    }
    public Models.Account? ValidateLogin(string email, string password)
    {
        bool isValid = false;
        AccountDataModel accountDataModel = _accountAccessor.GetAccountWithEmail(email);

        if (accountDataModel != null)
        {
            ILoginEngine oLoginEngine = new LoginEngine();
            isValid = oLoginEngine.ValidateLogin(accountDataModel, password);
        }
        
        return isValid == true ? AccountHelper.AccountDataModelToAccount(accountDataModel!) : null;
    }
}