using System;
using TachSpace.ProductManager.Domain.Entities;

namespace TechSpace.ProductManager.Application.Contracts;

public interface IProductRepository : IAsyncRepository<Product>
{
    Task<bool> IsProductNameUnique(string name);
}
