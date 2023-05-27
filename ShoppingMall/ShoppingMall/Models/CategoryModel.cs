namespace ShoppingMall.Models;

public class CategoryModel
{
    public string Name { get; set; }
    public Guid? ParentId { get; set; }
}