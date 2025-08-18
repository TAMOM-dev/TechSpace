using System;

namespace TechSpace.ProductManager.Application.Features.Products.Queries.GetProductsList;

public class ProductsListVm
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? ImageUrl { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public int Stock { get; set; }
}
