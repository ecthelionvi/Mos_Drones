using System;

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

        public Account(int accountId, string firstName, string lastName, string email, string password, Address accountAddress)
        {
            this.accountId = accountId;
            this.firstName = firstName;
            this.lastName = lastName;
            this.email = email;
            this.password = password;
            this.accountAddress = accountAddress;
        }
    }
}
