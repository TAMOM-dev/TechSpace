using System;
using MediatR;

namespace TechSpace.ProductManager.Application.Features.Categories.Queries.GetCategoriesList;

public class GetCategoriesListQuery : IRequest<List<CategoriesListVm>>
{

}
