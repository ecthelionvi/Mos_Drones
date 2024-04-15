using System;
using System.Reflection.Emit;

namespace Managers.Models
{
    public class Account
    {
        public int accountId { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public Address accountAddress { get; set; }
        public bool isAdmin { get; set; }

        public Account(int accountId, string firstName, string lastName, string email, string password, Address accountAddress, bool isAdmin)
        {
            this.accountId = accountId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.accountAddress = accountAddress;
            this.isAdmin = isAdmin;
        }

        public override string ToString()
        {
            string adminString = "";
            if (isAdmin)
            {
                adminString = "yes";
            }
            else
            {
                adminString = "no";
            }
            return $"accountId: {accountId}\nIs this user an admin? {adminString}\nEmail: {email}\nName: {firstName} {lastName}\nPassword: {password}\n{accountAddress}";
        }
    }
}
