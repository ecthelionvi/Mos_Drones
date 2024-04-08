using System;

public class Account
{
    private int accountId { get; set; }
    private string firstName { get; set; }
    private string lastName { get; set; }
    private string email { get; set; }
    private string password { get; set; }
    private Address accountAddress { get; set; }

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
