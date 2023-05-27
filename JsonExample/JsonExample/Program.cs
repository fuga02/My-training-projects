

using JsonExample;

var userService = new UserService();
userService.Read();
userService.Write();
foreach (var user in userService.Users)
{
    Console.WriteLine($"ismi : {user.Login} va paroli {user.Password}");
}