using System;

namespace TechSpace.ProductManager.Application.Features.Products.Queries.GetProductsExport;

public class ProductExportDto
{
    public Guid ProductId { get; set; }
    public string Name { get; set; } = string.Empty;
}
