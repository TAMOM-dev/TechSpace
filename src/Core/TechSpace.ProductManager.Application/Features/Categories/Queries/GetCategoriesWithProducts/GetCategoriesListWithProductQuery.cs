using System;
using MediatR;

namespace TechSpace.ProductManager.Application.Features.Categories.Queries.GetCategoriesWithProducts;

public class GetCategoriesListWithProductQuery : IRequest<List<CategoryProductListVm>>
{
    public bool IncludeHistory { get; set; }
}
