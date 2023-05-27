namespace JsonTraining;

public class User
{
    public string Login { get; set; }
    public string Password { get; set; }

    public User(string login, string password)
    {
        login = login;
        password = password;
    }
}