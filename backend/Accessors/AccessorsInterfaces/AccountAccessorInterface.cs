using System.Data.SqlClient;
using System.Net;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    interface IAccountAccessor
    {
        AccountDataModel GetAccountWithAccountId(int accountId);
        AccountDataModel GetAccountWithEmail(string email);
        int InsertAccount(AccountDataModel acc);
    }
}