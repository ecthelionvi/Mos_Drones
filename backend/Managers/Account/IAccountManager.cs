namespace Managers.Account;

public interface IAccountManager
{
    string AddAccount(Models.Account account);
    Models.Account? ValidateLogin(string email, string password);
}