

using Example;

var service = new UserService();

if (File.Exists("data.json"))
{
    service.Read();
}

foreach (var item in service.Users)
{
    Console.WriteLine($"ismi : {item.Name} va paroli {item.Password}, email : {item.Email}");
}
/*
var user1 = new User("fuga","asd12");
var user2 = new User("jasur","asd1");
var user3 = new User("oxun","asd1");
var user4 = new User("nimadir","asd");
service.Users.Add(user1);
service.Users.Add(user2);
service.Users.Add(user3);
service.Users.Add(user4);
service.Write();
*/



