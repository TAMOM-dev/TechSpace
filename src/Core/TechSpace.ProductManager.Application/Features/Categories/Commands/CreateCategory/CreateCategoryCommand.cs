using System;
using MediatR;

namespace TechSpace.ProductManager.Application.Features.Categories.Commands.CreateCategory;

public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
{
    public string Name { get; set; }
}
