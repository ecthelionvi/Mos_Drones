using System;
using System.Reflection.Emit;

namespace Managers.Account.Models;

    public class Account
    {
        public int? AccountId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Address.Address AccountAddress { get; set; }
        public bool IsAdmin { get; set; }

        public Account(int? accountId, string firstName, string lastName, string email, string password, Address.Address accountAddress, bool isAdmin)
        {
            this.AccountId = accountId;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.Password = password;
            this.AccountAddress = accountAddress;
            this.IsAdmin = isAdmin;
        }

        public override string ToString()
        {
            string adminString = IsAdmin ? "yes" : "no";
            return $"accountId: {AccountId}\nIs this user an admin? {adminString}\nEmail: {Email}\nName: {FirstName} {LastName}\nPassword: {Password}\n{AccountAddress}";
        }
    }

