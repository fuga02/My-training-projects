using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingMall.DataBase;
using ShoppingMall.Entities;
using ShoppingMall.Models;
using ShoppingMall.Services;

namespace ShoppingMall.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _context;

    public ProductController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetProductList()
    {
        var products = await _context.Products.ToListAsync();
        return Ok(products);
    }
    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetProductById(Guid id)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        { return NotFound(); }
        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromForm]ProductModel model)
    {
        var  product = new Product()
        {
            Name = model.Name,
            PhotoUrl = await FileService.SaveProductImage(model.PhotoUrl),
            Price = model.Price,
            CategoryId = model.CategoryId
        };
        _context.Products.Add(product);
        await _context.SaveChangesAsync();

        return Ok("It is done :)");
    }
    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateProduct(Guid id,[FromForm] ProductModel model)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
        if (product == null)
        {return NotFound();}
        product.Name = model.Name;
        product.Price = model.Price;
        product.CategoryId = model.CategoryId;
        product.PhotoUrl = await FileService.SaveProductImage(model.PhotoUrl);
        await _context.SaveChangesAsync();

        return Ok("It is done :)");
    }

}