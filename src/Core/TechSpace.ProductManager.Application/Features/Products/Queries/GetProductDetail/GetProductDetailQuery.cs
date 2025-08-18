using System;
using MediatR;

namespace TechSpace.ProductManager.Application.Features.Products.Queries.GetProductDetail;

public class GetProductDetailQuery : IRequest<ProductDetailVm>
{
    public Guid Id { get; set; }
}
