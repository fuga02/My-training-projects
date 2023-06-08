
using Microsoft.EntityFrameworkCore;
using PostgreSql_Training.Context;

var dbContext = new AppDbContext();
var users = 
dbContext.Users.FromSqlRaw("Select * from  users order by name;");
foreach (var user in users)
{
    Console.WriteLine(user.Name);
}