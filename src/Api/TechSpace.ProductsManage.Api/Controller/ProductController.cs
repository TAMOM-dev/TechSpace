using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TechSpace.ProductManager.Application.Features.Events.Commands;
using TechSpace.ProductManager.Application.Features.Products.Commands;
using TechSpace.ProductManager.Application.Features.Products.Queries.GetProductDetail;
using TechSpace.ProductManager.Application.Features.Products.Queries.GetProductsList;

namespace TechSpace.ProductsManage.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllProducts")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<List<ProductsListVm>>> GetAllProducts()
        {
            var result = await _mediator.Send(new GetProductsListQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetProductById")]
        public async Task<ActionResult<ProductDetailVm>> GetProductById(Guid id)
        {
            var query = new GetProductDetailQuery { Id = id };
            return Ok(await _mediator.Send(query));
        }

        [HttpPost(Name = "AddProduct")]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCommand command)
        {
            var id = await _mediator.Send(command);
            return Ok(id);
        }

        [HttpPut(Name = "UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Update([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete(Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Delete(Guid id)
        {
            var command = new DeleteProductCommand { ProductId = id };
            await _mediator.Send(command);
            return NoContent();
        }
    }
}
