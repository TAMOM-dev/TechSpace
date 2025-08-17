using System;
using AutoMapper;
using MediatR;
using TachSpace.ProductManager.Domain.Entities;
using TechSpace.ProductManager.Application.Contracts;

namespace TechSpace.ProductManager.Application.Features.Products.Queries.GetProductDetail;

public class GetProductDetailQueryHandler : IRequestHandler<GetProductDetailQuery, ProductDetailVm>
{
    private readonly IAsyncRepository<Product> _productRepository;
    private readonly IMapper _mapper;
    private readonly IAsyncRepository<Category> _categoryRepository;

    public GetProductDetailQueryHandler(
        IAsyncRepository<Product> productRepository,
        IAsyncRepository<Category> categoryRepository,
        IMapper mapper)
    {
        _productRepository = productRepository;
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<ProductDetailVm> Handle(GetProductDetailQuery request, CancellationToken cancellationToken)
    {
        var productEntity = await _productRepository.GetByIdAsync(request.Id);
        var productDetailVm = _mapper.Map<ProductDetailVm>(productEntity);

        var categoryEntity = await _categoryRepository.GetByIdAsync(productEntity.CategoryId);
        productDetailVm.Category = _mapper.Map<CategoryDto>(categoryEntity);

        return productDetailVm;
    }
}
