using System;
using AutoMapper;
using TachSpace.ProductManager.Domain.Entities;
using TechSpace.ProductManager.Application.Features.Categories.Commands.CreateCategory;
using TechSpace.ProductManager.Application.Features.Categories.Queries.GetCategoriesList;
using TechSpace.ProductManager.Application.Features.Categories.Queries.GetCategoriesWithProducts;
using TechSpace.ProductManager.Application.Features.Events.Commands;
using TechSpace.ProductManager.Application.Features.Products.Commands.CreateProduct;
using TechSpace.ProductManager.Application.Features.Products.Queries.GetProductDetail;
using TechSpace.ProductManager.Application.Features.Products.Queries.GetProductsList;

namespace TechSpace.ProductManager.Application.Profiles;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Mapping for Products
        CreateMap<Product, ProductsListVm>().ReverseMap();
        CreateMap<Product, ProductDetailVm>().ReverseMap();
        CreateMap<Category, CategoryDto>().ReverseMap();

        // Mapping for Categories
        CreateMap<Category, CategoriesListVm>().ReverseMap();
        CreateMap<Category, CategoryProductListVm>().ReverseMap();

        // Commands
        CreateMap<Product, CreateProductCommand>().ReverseMap();
        CreateMap<Product, UpdateProductCommand>().ReverseMap();
        CreateMap<Product, CreateProductDto>().ReverseMap();
        CreateMap<Product, CategoryProductDto>().ReverseMap();

        CreateMap<Category, CreateCategoryCommand>().ReverseMap();
        CreateMap<Category, CreateCategoryDto>().ReverseMap();

    }
}
