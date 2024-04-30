using System.Data.SqlClient;
using System.Net;
using Accessors.DBModels;

namespace Accessors.Accessors
{
    interface IAccountAccessor
    {
        public static AccountDataModel GetAccountWithAccountId(int accountId);
        public static AccountDataModel GetAccountWithEmail(string email);
        public static int InsertAccount(string firstName, string lastName, string email, string password, string city, string state, string zip, string addressLine, bool isAdmin);
    }
}