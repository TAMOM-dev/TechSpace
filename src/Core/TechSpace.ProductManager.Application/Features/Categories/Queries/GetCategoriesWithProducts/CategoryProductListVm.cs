using System;

namespace TechSpace.ProductManager.Application.Features.Categories.Queries.GetCategoriesWithProducts;

public class CategoryProductListVm
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; }
    public List<CategoryProductDto> Products { get; set; }
}
