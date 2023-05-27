using WebApi.Enums;

namespace WebApi.Models;

public class UserDto
{
    public required string Name { get; set; }
    public  required string Email { get; set; }
    public  required string Password { get; set; }
    public  required string Username { get; set; }
    public required EUser Status { get; set;}
}