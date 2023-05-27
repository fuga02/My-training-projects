
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Products.DataBase;
using Products.Entities;
using Products.Models;

namespace Products.Controllers;
[ApiController]
[Route("/api/[controller]")]
public class CategoriesController:ControllerBase
{
    private readonly AppDbContext _appDbContext;

    public CategoriesController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    [HttpGet]
    public async Task<List<Category>> GetList()
    {
        return await _appDbContext.Categories.ToListAsync();
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var category = await _appDbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return NotFound();
        }

        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryDto categoryDto)
    {
        if (categoryDto.ParentId != null
            && !await _appDbContext.Categories
                .AnyAsync(c => c.Id == categoryDto.ParentId))
        {
            return NotFound();
        }

        var category = new Category()
        {
            Name = categoryDto.Name,
            ParentId = categoryDto.ParentId,
        };

        _appDbContext.Categories.Add(category);
        await _appDbContext.SaveChangesAsync();

        return Ok(category);
    }

    [HttpDelete]
    public async Task<IActionResult> Delete(Guid id)
    {
        var category = await _appDbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return NotFound();
        }

        _appDbContext.Categories.Remove(category);
        await _appDbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] CreateCategoryDto categoryDto)
    {
        var category = await _appDbContext.Categories
            .FirstOrDefaultAsync(c => c.Id == id);

        if (category == null)
        {
            return NotFound();
        }

        category.Name = categoryDto.Name;
        await _appDbContext.SaveChangesAsync();

        return Ok(category);
    }

}