using System;
using MediatR;

namespace TechSpace.ProductManager.Application.Features.Products.Queries.GetProductsList;

public class GetProductsListQuery : IRequest<List<ProductsListVm>>
{

}
