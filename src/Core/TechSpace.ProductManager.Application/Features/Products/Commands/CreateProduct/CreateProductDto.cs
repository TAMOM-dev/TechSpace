using System;

namespace TechSpace.ProductManager.Application.Features.Products.Commands.CreateProduct;

public class CreateProductDto
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
}
