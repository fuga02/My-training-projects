using System.ComponentModel.DataAnnotations.Schema;

namespace PostgreSql_Training;
[Table("users")]
public class User
{
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    public required string Name { get; set; }

    [Column("is_admin")]
    public bool IsAdmin { get; set; }

    [Column("age")]
    public int Age { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, IsAdmin: {IsAdmin}, Age: {Age}";
    }
}