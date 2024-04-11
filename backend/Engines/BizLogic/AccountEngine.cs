using System;
using System.Text.RegularExpressions;

namespace Engines {
    public class AccountEngine
    {
        // password input validation, use when creating an account
        public bool ValidPasswordStrength(string password)
        {
            // password must contain at least 1 lowercase letter, 1 uppercase letter, 
            // 1 number, and be between 8-20 characters long
            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,20}$");
        }

        public void ValidateSignUp(string email, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new InvalidOperationException("Password field is empty");
            }
            else if (string.IsNullOrEmpty(email))
            {
                throw new InvalidOperationException("Email field is empty");
            }
            else if (!ValidPasswordStrength(password))
            {
                throw new InvalidOperationException("Password does not meet requirements.");
            }
            // check if account with the entered email already exists
            else if ()
            {
                // get account from database using email, if the result != null
                throw new InvalidOperationException("Account with the entered email already exists");
            }
            else
            {
                // take user to dashboard
            }
        }

        public void ValidateLogin(string email, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new InvalidOperationException("Please enter your password");
            }
            else if (string.IsNullOrEmpty(email))
            {
                throw new InvalidOperationException("Please enter your email");
            }
            else
            {
                // get account with the email and see if password matches
                // what was entered
                if ()
                {
                    // take user to dashboard
                }
                else
                {
                    throw new InvalidOperationException("The password or email entered is incorrect");
                }
            }
        }
    }
}
