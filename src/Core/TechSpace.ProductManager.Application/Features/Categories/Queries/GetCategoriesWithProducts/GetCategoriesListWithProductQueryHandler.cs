using System;
using AutoMapper;
using MediatR;
using TechSpace.ProductManager.Application.Contracts;

namespace TechSpace.ProductManager.Application.Features.Categories.Queries.GetCategoriesWithProducts;

public class GetCategoriesListWithProductQueryHandler : IRequestHandler<GetCategoriesListWithProductQuery, List<CategoryProductListVm>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetCategoriesListWithProductQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<List<CategoryProductListVm>> Handle(GetCategoriesListWithProductQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetCategoriesWithProducts();
        return _mapper.Map<List<CategoryProductListVm>>(categories);
    }
}
