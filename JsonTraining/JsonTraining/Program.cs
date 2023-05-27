
using JsonTraining;

Console.WriteLine("Hello, World!");

var userService = new UserService();
/*var user1 = new User("fuga","asd1");
var user2 = new User("ali","asd");
userService.Users.Add(user1);
userService.Users.Add(user2);
userService.Write();*/

userService.Read();
foreach (var user in userService.Users)
{
    Console.WriteLine($"Login : {user.Login} and password {user.Password}");
}
