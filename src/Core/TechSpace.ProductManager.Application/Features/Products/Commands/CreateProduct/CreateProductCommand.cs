using System;
using MediatR;
using TechSpace.ProductManager.Application.Features.Products.Commands.CreateProduct;

namespace TechSpace.ProductManager.Application.Features.Events.Commands;

public class CreateProductCommand : IRequest<CreateProductCommandResponse>
{
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
    public override string ToString()
    {
        return $"Product Name: {Name}; Price: {Price}; In Stock: {Stock}; Description: {Description}";
    }

}
