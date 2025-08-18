using System;
using Microsoft.EntityFrameworkCore;
using TachSpace.ProductManager.Domain.Entities;
using TechSpace.ProductManager.Application.Contracts;

namespace TechSpace.ProductManager.Persistence.Repositories;

public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(TechSpaceDbContext context) : base(context)
    {
    }

    public async Task<List<Category>> GetCategoriesWithProducts()
    {
        var allCategories = await _context.Categories.Include(x => x.Products).ToListAsync();
        return allCategories;
    }
}
