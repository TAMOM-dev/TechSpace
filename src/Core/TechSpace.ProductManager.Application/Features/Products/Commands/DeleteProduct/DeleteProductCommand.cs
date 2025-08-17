using System;
using MediatR;

namespace TechSpace.ProductManager.Application.Features.Products.Commands;

public class DeleteProductCommand : IRequest<Unit>
{
    public Guid ProductId { get; set; }
}
