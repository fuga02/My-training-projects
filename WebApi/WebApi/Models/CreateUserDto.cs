namespace WebApi.Models;

public class CreateUserDto
{
    public required string Password { get; set; }
    public required string Username { get; set; }
}