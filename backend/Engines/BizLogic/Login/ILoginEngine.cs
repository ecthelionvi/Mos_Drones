using Accessors.Account.Models;

namespace Engines.BizLogic.Login;

public interface ILoginEngine
{
    bool ValidateLogin(AccountDataModel account, string password);
}