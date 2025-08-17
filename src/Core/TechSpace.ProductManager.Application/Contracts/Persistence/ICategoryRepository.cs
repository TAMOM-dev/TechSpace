using System;
using TachSpace.ProductManager.Domain.Entities;

namespace TechSpace.ProductManager.Application.Contracts;

public interface ICategoryRepository : IAsyncRepository<Category>
{
    // Additional methods specific to Category can be added here
    Task<List<Category>> GetCategoriesWithProducts();
}
