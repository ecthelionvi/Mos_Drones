using System;
using System.Text.RegularExpressions;
using Accessors.Accessors;
using Accessors.DBModels;

namespace Engines.BizLogic  
{
    public class AccountEngine
    {
        /// <summary>
        /// This method returns true if the email doesn't already exist, else returns false.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ValidateSignUp(string email, string password)
        {
            AccountDataModel account = AccountAccessor.GetAccountWithEmail(email);
            if (account != null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// This method if the password used to login matches the existing Account's password.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static bool ValidateLogin(AccountDataModel account, string password)
        {
            return (string.Compare(account.Password, password) == 0);
        }
    }
}
