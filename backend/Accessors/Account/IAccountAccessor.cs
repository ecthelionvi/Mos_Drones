using System.Data.SqlClient;
using System.Net;
using Accessors.Account.Models;

namespace Accessors.Account
{
    public interface IAccountAccessor
    {
        AccountDataModel GetAccountWithAccountId(int accountId);
        AccountDataModel GetAccountWithEmail(string email);
        Task<int> InsertAccount(AccountDataModel acc);
    }
}