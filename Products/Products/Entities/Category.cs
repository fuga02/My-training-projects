using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Entities;

public class Category
{
    [Key]
    public Guid Id { get; set; }
    public string Name { get; set; }
    [ForeignKey("ParentId")]
    public Guid? ParentId { get; set; }
    public Category? Parent { get; set; }
    public List<Category>? Children { get; set; }
    public List<Product>? Products { get; set; }
}