using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week2.Application.Features.Commands.DiscountCommands.CreateDiscount;
using Week2.Application.Features.Commands.DiscountCommands.DeleteDiscount;
using Week2.Application.Features.Commands.DiscountCommands.UpadateDiscount;
using Week2.Application.Features.Queries.DiscountQueries.GetAllDiscounts;
using Week2.Application.Features.Queries.DiscountQueries.GetByIdDiscount;
using Week2.Application.Features.Queries.DiscountQueries.SearchDiscountQueryHandler;

namespace Week2.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        IMediator _mediator;

        public DiscountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllDiscountsQueryResponse>> Get()
        {
            return (List<GetAllDiscountsQueryResponse>)await _mediator.Send(new GetAllDiscountsQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdDiscountQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdDiscountQueryRequest { Id = id });
        }

        [HttpPost]
        public async Task<CreateDiscountCommandResponse> CreateProduct([FromBody] CreateDiscountCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<UpdateDiscountCommandResponse> UpdateProduct([FromForm] UpdateDiscountCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteDiscountCommandResponse> DeleteProduct(string id)
        {
            return await _mediator.Send(new DeleteDiscountCommandRequest { Id = id });
        }

        [HttpGet("search")]
        public async Task<IEnumerable<SearchDiscountQueryResponse>> SearchDiscountQueries([FromQuery] SearchDiscountQueryRequest request)
        {
            return await _mediator.Send(request);
        }

    }
}
