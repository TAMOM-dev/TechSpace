using System;
using TechSpace.ProductManager.Application.Features.Products.Queries.GetProductsExport;

namespace TechSpace.ProductManager.Application.Contracts.Infrastructure;

public interface ICsvExporter
{
    byte[] ExportProductsToCsv(List<ProductExportDto> productsExportDto);
}
