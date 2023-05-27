namespace Mapper.Entities;

public class User
{
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public DateTime Created { get; set; }
    = DateTime.Now;

    public User (string userName, string password, string email)
    {
        UserName = userName;
        Password = password;
        Email = email;
    }

    public User()
    {

    }
}