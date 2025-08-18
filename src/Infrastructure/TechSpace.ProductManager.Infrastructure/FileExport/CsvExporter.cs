using System;
using System.Text;
using CsvHelper;
using TechSpace.ProductManager.Application.Contracts.Infrastructure;
using TechSpace.ProductManager.Application.Features.Products.Queries.GetProductsExport;

namespace TechSpace.ProductManager.Infrastructure.FileExport;

public class CsvExporter : ICsvExporter
{
    public byte[] ExportProductsToCsv(List<ProductExportDto> productsExportDto)
    {
        using var memoryStream = new MemoryStream();
        using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8))
        {
            using var csvWriter = new CsvWriter(streamWriter);
            csvWriter.WriteRecords(productsExportDto); // Writes the records to the CSV file
        }

        return memoryStream.ToArray();
    }
}
