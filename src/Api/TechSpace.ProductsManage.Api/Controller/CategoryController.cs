using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSpace.ProductManager.Application.Features.Categories.Commands.CreateCategory;
using TechSpace.ProductManager.Application.Features.Categories.Queries.GetCategoriesList;
using TechSpace.ProductManager.Application.Features.Categories.Queries.GetCategoriesWithProducts;

namespace TechSpace.ProductsManage.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("all", Name = "GetAllCategories")]
        public async Task<ActionResult<List<CategoryProductListVm>>> GetAllCategories()
        {
            var dtos = await _mediator.Send(new GetCategoriesListQuery());
            return Ok(dtos);
        }


        [HttpGet("allWithProducts", Name = "GetAllCategoriesWithProducts")]
        public async Task<ActionResult<List<CategoryProductListVm>>> GetAllCategoriesWithProducts()
        {
            var query = new GetCategoriesListWithProductQuery();
            var dtos = await _mediator.Send(query);
            return Ok(dtos);
        }

        [HttpPost(Name = "AddCategory")]
        public async Task<ActionResult<CreateCategoryCommandResponse>> Create([FromBody] CreateCategoryCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
