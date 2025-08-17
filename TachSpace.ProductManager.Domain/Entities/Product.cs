using System;
using TachSpace.ProductManager.Domain.Common;

namespace TachSpace.ProductManager.Domain.Entities;

public class Product : AuditableEntity
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
}