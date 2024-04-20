namespace Accessors.DBModels;

public class AccountDataModel
{
    private int AccountId { get; set; }
    private string FirstName { get; set; }
    private string LastName { get; set; }
    private string Email { get; set; }
    private string Password { get; set; }
    private AddressDataModel AccountAddress { get; set; }
    private bool IsAdmin { get; set; }

    public AccountDataModel(int accountId, string firstName, string lastName, string email, string password, AddressDataModel accountAddress, bool isAdmin)
    {
        this.AccountId = accountId;
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Email = email;
        this.Password = password;
        this.AccountAddress = accountAddress;
        this.IsAdmin = isAdmin;
    }

    public string GetPassword() { return Password; }
    public override string ToString()
    {
        string adminString = IsAdmin ? "yes" : "no";
        return $"accountId: {AccountId}\nIs this user an admin? {adminString}\nEmail: {Email}\nName: {FirstName} {LastName}\nPassword: {Password}\n{AccountAddress}";
    }    
}
