using System.ComponentModel.DataAnnotations.Schema;

namespace Identity.Api.Entities;

[Table("users1")]
public class User
{
    public Guid Id { get; set; }
    public required string? FirstName { get; set; }
    public required string Username { get; set; }
    public  string? Email { get; set; }
    public required string Password { get; set; }

}