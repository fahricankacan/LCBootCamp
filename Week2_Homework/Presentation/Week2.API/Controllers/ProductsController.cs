using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week2.Application.Features.Commands.ProductCommands.CreateProduct;
using Week2.Application.Features.Commands.ProductCommands.DeleteProduct;
using Week2.Application.Features.Commands.ProductCommands.UpdateProduct;
using Week2.Application.Features.Queries.ProductQueries.GetAllProducts;
using Week2.Application.Features.Queries.ProductQueries.GetByIdProduct;
using Week2.Application.Features.Queries.ProductQueries.SearchProduct;

namespace Week2.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllProductQueryResponse>> Get()
        {
            return await _mediator.Send(new GetAllProductQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdProductQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdProductQueryRequest { Id = id });
        }
       

        [HttpPost]
        public async Task<CreateProductCommandResponse> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<UpdateProductCommandResponse> UpdateProduct([FromForm] UpdateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteProductCommandResponse> DeleteProduct(string id)
        {
            return await _mediator.Send(new DeleteProductCommandRequest { Id = id });
        }
        [HttpGet("search")]
        public async Task<IEnumerable<SearchProductQueryResponse>> Search([FromQuery] SearchProductQueryRequest request)
        {
            return await _mediator.Send(request);
        }
       
    }
}
