using System;
using TechSpace.ProductManager.Application.Responses;

namespace TechSpace.ProductManager.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandResponse : BaseResponse
{
    public CreateProductCommandResponse() : base()
    {

    }

    public CreateProductDto ProductDto { get; set; } = default!;
}
