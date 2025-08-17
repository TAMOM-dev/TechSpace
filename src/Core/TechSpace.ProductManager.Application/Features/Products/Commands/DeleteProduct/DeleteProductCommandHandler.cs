using System;
using MediatR;
using TechSpace.ProductManager.Application.Contracts;

namespace TechSpace.ProductManager.Application.Features.Products.Commands;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;

    public DeleteProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }


    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _productRepository.GetByIdAsync(request.ProductId);
        if (productEntity == null) throw new ArgumentException("Product not found");

        await _productRepository.DeleteAsync(productEntity);

        return Unit.Value;
    }
}
