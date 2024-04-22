using System;
using System.Text.RegularExpressions;
using Accessors.Accessors;
using Accessors.DBModels;

namespace Engines.BizLogic  
{
    public class AccountEngine
    {
        /// <summary>
        /// Performs password input validation using regular expressions.
        /// Returns true if the given password matches the expected pattern and false otherwise.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool ValidPasswordStrength(string password)
        {
            // password must contain at least 1 lowercase letter, 1 uppercase letter, 
            // 1 number, and be between 8-20 characters long
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,20}$");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void ValidateSignUp(string email, string password)
        {
            if (!ValidPasswordStrength(password))
            {
                throw new InvalidOperationException("Password does not meet requirements.");
            }
            // check if account with the entered email already exists
            AccountDataModel account = AccountAccessor.GetAccountWithEmail(email);
            if (account != null)
            {
                throw new InvalidOperationException("Account with the entered email already exists.");
            }
        }

        /// <summary>
        /// This method gets the Account instance with the given email and checks if the password used to 
        /// login matches the existing Account's password.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <exception cref="InvalidOperationException"></exception>
        public static void ValidateLogin(string email, string password)
        {
            // get account with the email and see if password matches what was entered
            AccountDataModel account = AccountAccessor.GetAccountWithEmail(email);
            string accountPassword = account.GetPassword();

            if (accountPassword != password)
            {
                throw new InvalidOperationException("The password or email entered is incorrect");
            } 
        }
    }
}
