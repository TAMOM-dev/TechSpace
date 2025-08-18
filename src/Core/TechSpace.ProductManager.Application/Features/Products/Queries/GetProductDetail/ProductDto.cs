using System;

namespace TechSpace.ProductManager.Application.Features.Products.Queries.GetProductDetail;

public class ProductDto
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } 
    public string ImageUrl { get; set; }
    public string Description { get; set; } 
    public int Stock { get; set; }
    public decimal Price { get; set; }
}
