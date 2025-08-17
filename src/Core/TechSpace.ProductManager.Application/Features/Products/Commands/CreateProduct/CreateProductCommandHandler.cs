using System;
using AutoMapper;
using MediatR;
using TachSpace.ProductManager.Domain.Entities;
using TechSpace.ProductManager.Application.Contracts;
using TechSpace.ProductManager.Application.Contracts.Infrastructure;
using TechSpace.ProductManager.Application.Features.Events.Commands;
using TechSpace.ProductManager.Application.Models.Mail;

namespace TechSpace.ProductManager.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, CreateProductCommandResponse>
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;
    private readonly IEmailService _emailService;

    public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper, IEmailService emailService)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _emailService = emailService;
    }

    public async Task<CreateProductCommandResponse> Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        var theProduct = _mapper.Map<Product>(request);
        var createProductCommandResponse = new CreateProductCommandResponse();
        var validator = new CreateProductCommandValidation(_productRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Count > 0)
        {
            createProductCommandResponse.Success = false;
            createProductCommandResponse.ValidationErrors = new List<string>();
            foreach (var error in validationResult.Errors)
            {
                createProductCommandResponse.ValidationErrors.Add(error.ErrorMessage);
            }
        }

        if (createProductCommandResponse.Success)
        {
            theProduct = await _productRepository.AddAsync(theProduct);
            createProductCommandResponse.ProductDto = _mapper.Map<CreateProductDto>(theProduct);
            var email = new Email() { To = "max333wirfredo@gmail.com", Body = $"A new product was created: {request}", Subject = "A new product was created" };

            // Sending email to admin
            try
            {
                await _emailService.SendEmail(email);
            }
            catch (Exception ex)
            {

            }
        }

        return createProductCommandResponse;
        
    }
}
}


