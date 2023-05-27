using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models;

public class CreateCategoryDto
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}