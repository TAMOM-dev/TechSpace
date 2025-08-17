using System;

namespace TechSpace.ProductManager.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryDto
{
    public Guid CategoryId { get; set; }
    public string Name { get; set; } = string.Empty;
}
