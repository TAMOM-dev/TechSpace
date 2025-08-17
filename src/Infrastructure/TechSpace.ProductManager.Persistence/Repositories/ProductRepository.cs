using System;
using TachSpace.ProductManager.Domain.Entities;
using TechSpace.ProductManager.Application.Contracts;

namespace TechSpace.ProductManager.Persistence.Repositories;

public class ProductRepository : BaseRepository<Product>, IProductRepository
{
    public ProductRepository(TechSpaceDbContext context) : base(context)
    {
    }
    public Task<bool> IsProductNameUnique(string name)
    {
        var matches = _context.Products.Any(p => p.Name.Equals(name));
        return Task.FromResult(matches); 
    }
}
