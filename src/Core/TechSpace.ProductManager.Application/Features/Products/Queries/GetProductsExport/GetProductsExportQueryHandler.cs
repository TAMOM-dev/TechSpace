using System;
using AutoMapper;
using MediatR;
using TachSpace.ProductManager.Domain.Entities;
using TechSpace.ProductManager.Application.Contracts;
using TechSpace.ProductManager.Application.Contracts.Infrastructure;

namespace TechSpace.ProductManager.Application.Features.Products.Queries.GetProductsExport;

public class GetProductsExportQueryHandler : IRequestHandler<GetProductsExportQuery, ProductExportFileVm>
{
    private readonly IAsyncRepository<Product> _productRepository;
    private readonly IMapper _mapper;
    private readonly ICsvExporter _csvExporter;

    public GetProductsExportQueryHandler(IMapper mapper, IAsyncRepository<Product> productRepository, ICsvExporter csvExporter)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _csvExporter = csvExporter;
    }

    public async Task<ProductExportFileVm> Handle(GetProductsExportQuery request, CancellationToken cancellationToken)
    {
        var allProducts = _mapper.Map<List<ProductExportDto>>((await _productRepository.ListAllAsync()).OrderBy(x => x.LastModifiedOn));
        var fileData = _csvExporter.ExportProductsToCsv(allProducts);

        return new ProductExportFileVm
        {
            ProductExportFileName = $"{Guid.NewGuid()}.csv",
            ContentType = "text/csv",
            Data = fileData
        };
    }
}
