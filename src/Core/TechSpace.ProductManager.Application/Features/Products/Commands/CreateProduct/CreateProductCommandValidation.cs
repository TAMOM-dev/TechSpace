using System;
using System.Data;
using FluentValidation;
using TechSpace.ProductManager.Application.Contracts;
using TechSpace.ProductManager.Application.Features.Events.Commands;

namespace TechSpace.ProductManager.Application.Features.Products.Commands.CreateProduct;

public class CreateProductCommandValidation : AbstractValidator<CreateProductCommand>
{
    private readonly IProductRepository _productRepository;

    public CreateProductCommandValidation(IProductRepository productRepository)
    {
        _productRepository = productRepository;

        RuleFor(p => p.Name)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be less than 50 characters");

        RuleFor(p => p.Stock)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");

        RuleFor(e => e)
            .MustAsync(ProductNameUnique)
            .WithMessage("A product with the same name already exists");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0");
    }

    private async Task<bool> ProductNameUnique(CreateProductCommand e, CancellationToken token)
    {
        return !await _productRepository.IsProductNameUnique(e.Name);
    }

}
