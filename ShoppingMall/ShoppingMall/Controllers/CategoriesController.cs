using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingMall.DataBase;
using ShoppingMall.Entities;
using ShoppingMall.Models;

namespace ShoppingMall.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly AppDbContext _context;

    public CategoriesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<CategoryDto>> GetCategoriesList()
    {
        var categories = await _context.Categories
            .Where(c => c.ParentId == null)
            .ToListAsync();

        return await MapTo(categories);
    }

    private async Task<List<CategoryDto>> MapTo(List<Category> categories)
    {
        var categoriesDto = new List<CategoryDto>();
        foreach (var category in categories)
        {
            categoriesDto.Add(await MapToDto(category));
        }
        return categoriesDto;
    }

    private async Task<CategoryDto> MapToDto(Category category)
    {
        await _context.Entry(category).Collection(c => c.Children).LoadAsync();
        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Children = await MapTo(category.Children)
        };
    }


    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCategoryById(Guid id)
    {
        var category = await _context.Categories.SingleOrDefaultAsync(c => c.Id == id);
        if (category == null)
        { return NotFound();}
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> AddCategory([FromBody] CategoryModel model)
    {
        var category = new Category();
        if (model.ParentId != null && !await _context.Categories.AnyAsync(c => c.ParentId != model.ParentId))
        {
            category.Name = model.Name;
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return Ok();
        }
        category.Name = model.Name;
        category.ParentId = model.ParentId;
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();
        return Ok();
        
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategory(Guid id,[FromBody] CategoryModel model)
    {
        var category = _context.Categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            category.ParentId = model.ParentId;
            category.Name = model.Name;
           await  _context.SaveChangesAsync();
           return Ok();
        }

        return NotFound();
    }

}