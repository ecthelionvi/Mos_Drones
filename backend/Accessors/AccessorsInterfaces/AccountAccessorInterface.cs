using System.Data.SqlClient;
using System.Net;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    interface IAccountAccessor
    {
        AccountDataModel GetAccountWithAccountId(int accountId);
        AccountDataModel GetAccountWithEmail(string email);
        int InsertAccount(string firstName, string lastName, string email, string password, string city, string state, string zip, string addressLine, bool isAdmin);
    }
}