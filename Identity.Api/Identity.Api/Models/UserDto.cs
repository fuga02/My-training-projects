using System.ComponentModel.DataAnnotations;

namespace Identity.Api.Models;

public class UserDto
{
    public required string? FirstName { get; set; }
    public required string Username { get; set; }
    public string? Email { get; set; }
    public required string Password { get; set; }

    [Compare(nameof(Password))]
    public required string? ConfirmPassword { get; set;}

}