using System;
using AutoMapper;
using MediatR;
using TachSpace.ProductManager.Domain.Entities;
using TechSpace.ProductManager.Application.Contracts;
using TechSpace.ProductManager.Application.Features.Events.Commands;

namespace TechSpace.ProductManager.Application.Features.Products.Commands;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public UpdateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var productEntity = await _productRepository.GetByIdAsync(request.ProductId);
        if (productEntity == null) throw new ArgumentException("Product not found");

        _mapper.Map(request, productEntity);
        await _productRepository.UpdateAsync(productEntity);

        return Unit.Value;
    }
}
