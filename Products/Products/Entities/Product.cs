using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Entities;

public class Product
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    public long Price { get; set; }
    public string PhotoUrl { get; set; }
    [ForeignKey("CategoryId")]
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}