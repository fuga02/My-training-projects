using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassRoomData.Entities;
[Table("schools")]
public class School
{
    [Key]
    public Guid Id { get; set; }
    [Column("name")]
    [StringLength(50)]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("photo_url")]
    public string PhotoUrl { get; set; }
    public List<UserSchool> UserSchools { get; set; }
}