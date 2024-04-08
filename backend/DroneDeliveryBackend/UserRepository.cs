using System.Collections.Generic;

public class UserRepository
{
    private readonly List<User> _users = new List<User>();

    public UserRepository()
    {
        // Add the user robert.scott.sears@gmail.com as a staff member
        _users.Add(new User
        {
            Email = "robert.scott.sears@gmail.com",
            Role = "staff"
        });
    }

    public User GetUserByEmail(string email)
    {
        return _users.Find(user => user.Email == email);
    }
}
