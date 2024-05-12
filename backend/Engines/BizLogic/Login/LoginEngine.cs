using System;
using System.Text.RegularExpressions;
using Accessors.Account.Models;

//account accessor
namespace Engines.BizLogic.Login 
{
    public class LoginEngine : ILoginEngine
    {
        public bool ValidateLogin(AccountDataModel account, string password)
        {
            return (string.Compare(account.Password, password) == 0);
        }
    }
}
