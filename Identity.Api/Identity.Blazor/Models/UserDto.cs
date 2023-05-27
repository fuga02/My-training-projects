using System.ComponentModel.DataAnnotations;

namespace Identity.Blazor.Models;

public class UserDto
{
    public  string? FirstName { get; set; }
    public  string Username { get; set; }
    public string? Email { get; set; }
    public  string Password { get; set; }

    [Compare(nameof(Password))]
    public  string? ConfirmPassword { get; set;}

}