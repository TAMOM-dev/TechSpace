using System;
using AutoMapper;
using MediatR;
using TachSpace.ProductManager.Domain.Entities;
using TechSpace.ProductManager.Application.Contracts;

namespace TechSpace.ProductManager.Application.Features.Products.Queries.GetProductsList;

public class GetProductsListQueryHandler : IRequestHandler<GetProductsListQuery, List<ProductsListVm>>
{
    private readonly IAsyncRepository<Product> _productRepository;
    private readonly IMapper _mapper;

    public GetProductsListQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository)
    {
        _mapper = mapper;
        _productRepository = productRepository;
    }

    public async Task<List<ProductsListVm>> Handle(GetProductsListQuery request, CancellationToken cancellationToken)
    {
        var allProducts = (await _productRepository.ListAllAsync()).ToList();
        return _mapper.Map<List<ProductsListVm>>(allProducts);
    }
}
