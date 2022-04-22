using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week2.Application.Features.Commands.ProductCommands.CreateProduct;
using Week2.Application.Features.Commands.ProductCommands.DeleteProduct;
using Week2.Application.Features.Commands.ProductCommands.UpdateProduct;
using Week2.Application.Features.Queries.ProductQueries.GetAllProducts;
using Week2.Application.Features.Queries.ProductQueries.GetByIdProduct;

namespace Week2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllProductQueryResponse>> Get()
        {
            return await _mediator.Send(new GetAllProductQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdProductQueryResponse> GetById([FromQuery] GetByIdProductQueryRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<CreateProductCommandResponse> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("{id}")]
        public async Task<UpdateProductCommandResponse> UpdateProduct([FromBody] UpdateProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteProductCommandResponse> DeleteProduct([FromQuery] DeleteProductCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
