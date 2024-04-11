using System;

namespace Managers
{
    public class User
    {
        public int userId { get; set; }
        public bool isAdmin { get; set; }
        public Account userAccount { get; set; }

        public User(int userId, bool isAdmin, Account userAccount)
        {
            this.userId = userId;
            this.isAdmin = isAdmin;
            this.userAccount = userAccount;
        }
    }
}
