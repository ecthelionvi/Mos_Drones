using System;

public class User
{
    private int userId { get; set; }
    private bool isAdmin { get; set; }
    private Account userAccount { get; set; }

    public User(int userId, bool isAdmin, Account userAccount)
    {
        this.userId = userId;
        this.isAdmin = isAdmin;
        this.userAccount = userAccount;
    }
}
