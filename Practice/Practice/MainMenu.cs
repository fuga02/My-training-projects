namespace Practice;

public class MainMenu
{
    private Dictionary<string, User> users = new Dictionary<string, User>();
    

    public void Menu()
    {
        Console.WriteLine("Hush kelibsiz");
        Console.WriteLine("1. Royhatdan otish");
        Console.WriteLine("2. Kirish");
        Console.Write(">>>");
        string word = Console.ReadLine()!;

        if (word == "1")
        {
            SignUp();
        }
        else if (word == "2")
        {
            LogIn();
        }
        else
        {
            Menu();
        }
    }



    private void LogIn()
    {
        Console.Write("Usernamizni kiriting>>>");
        string username = Console.ReadLine()!;
        Console.Write("Password kiriting>>>");
        string password = Console.ReadLine()!;

        bool checkUser = users.ContainsKey(username);

        if (checkUser)
        {
            User user = users[username];

            if (user.Password == password)
            {
                Console.WriteLine($"{user.Username} xosh kelibsiz");
            }
            else
            {
                Console.WriteLine("Passwordni xato kiritdingiz. iltimos qayta orinib koring :)");

                LogIn();
            }
        }
        else
        {
            Console.WriteLine("Bunaqa user yoq, iltimos royhatdan oting");
            Menu();
        }


    }

    private  void SignUp()
    {
        Console.Write("Usernamizni kiriting>>>");
        string username = Console.ReadLine()!;
        Console.Write("Password kiriting>>>");
        string password = Console.ReadLine()!;

        User user = new User();
        user.Username = username;
        user.Password = password;

        users.Add(user.Username, user);
        ShowUserMenu();
    }



    private void ShowUserMenu()
    {
        Console.WriteLine("1. Pul o'tkazmalari");
        Console.WriteLine("2. tulovlar");
        Console.WriteLine("1. balans");
        Console.WriteLine("1. dastur xaqida malumot");
        Console.Write(">>>");
        var word = Console.ReadLine()!;
        switch (word)
        {
            case "1": SignUp(); break;
        }
    }
}