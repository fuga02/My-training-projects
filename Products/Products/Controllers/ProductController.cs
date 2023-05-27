using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.DataBase;
using Products.Entities;
using Products.FileServices;
using Products.Models;

namespace Products.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class ProductController : ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public ProductController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<List<Product>> GetList()
    {
        return await _appDbContext.Products.ToListAsync();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var product = await _appDbContext.Products
            .FirstOrDefaultAsync(c => c.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] CreateProductDto productDto)
    {
        if (!await _appDbContext.Categories
                .AnyAsync(c => c.Id == productDto.CategoryId))
        {
            return NotFound();
        }

        var product = new Product()
        {
            Name = productDto.Name,
            Price = productDto.Price,
            CategoryId = productDto.CategoryId,
            PhotoUrl = await FileService.SaveProductImage(productDto.Photo!)
        };

        _appDbContext.Products.Add(product);
        await _appDbContext.SaveChangesAsync();

        return Ok(product);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _appDbContext.Products
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return NotFound();
        }

        _appDbContext.Products.Remove(category);
        await _appDbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateProductDto productDto)
    {
        var product = await _appDbContext.Products
            .FirstOrDefaultAsync(c => c.Id == id);

        if (product == null)
        {
            return NotFound();
        }

        product.Name = productDto.Name;
        product.Price = productDto.Price;
        await _appDbContext.SaveChangesAsync();

        return Ok(product);
    }

}