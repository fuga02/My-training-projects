using Mapper.Entities;
using Mapper.Extentions;
using Mapper.Models;
using Mapster;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var user = new User("fuga_02", "coca02", "marufberdiyev02@gmail.com");
var dto = user.Adapt<UserModel>();
Console.WriteLine($"{dto.Email} : {dto.Password} : {dto.UserName} : {user.Created}"); 
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
