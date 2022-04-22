using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week2.Application.Features.Commands.DiscountCommands.CreateDiscount;
using Week2.Application.Features.Commands.DiscountCommands.DeleteDiscount;
using Week2.Application.Features.Commands.DiscountCommands.UpadateDiscount;
using Week2.Application.Features.Queries.DiscountQueries.GetAllDiscounts;
using Week2.Application.Features.Queries.DiscountQueries.GetByIdDiscount;

namespace Week2.API.Controllers
{
    [Route("api/[controller]")]
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
        public async Task<GetByIdDiscountQueryResponse> GetById([FromQuery] GetByIdDiscountQueryRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPost]
        public async Task<CreateDiscountCommandResponse> CreateProduct([FromBody] CreateDiscountCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut("{id}")]
        public async Task<UpdateDiscountCommandResponse> UpdateProduct([FromBody] UpdateDiscountCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteDiscountCommandResponse> DeleteProduct([FromQuery] DeleteDiscountCommandRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
