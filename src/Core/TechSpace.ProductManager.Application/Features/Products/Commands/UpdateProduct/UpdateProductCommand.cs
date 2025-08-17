using System;
using MediatR;

namespace TechSpace.ProductManager.Application.Features.Events.Commands;

public class UpdateProductCommand : IRequest<Unit>
{
    public Guid ProductId { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public decimal Price { get; set; }
    public Guid CategoryId { get; set; }
}
