namespace Products.Models;

public class CreateProductDto
{
    public string Name { get; set; }
    public long Price { get; set; }
    public IFormFile? Photo { get; set; }
    public Guid CategoryId { get; set; }
}