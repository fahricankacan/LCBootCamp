using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week2.Application.Features.Commands.InventoryCommands.CreateInventory;
using Week2.Application.Features.Commands.InventoryCommands.DeleteIncentory;
using Week2.Application.Features.Commands.InventoryCommands.UpdateInventory;
using Week2.Application.Features.Queries.InventoryQueries.GetAllInventories;
using Week2.Application.Features.Queries.InventoryQueries.GetByIdInventory;
using Week2.Application.Features.Queries.InventoryQueries.SearchInventory;

namespace Week2.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class InventoriesController : ControllerBase
    {
        IMediator _mediator;

        public InventoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllInventoriesQueryResponse>> Get()
        {
            return (List<GetAllInventoriesQueryResponse>)await _mediator.Send(new GetAllInventoriesQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdInventoryQueryResponse> GetById(string id)
        {

            return await _mediator.Send(new GetByIdInventoryQueryRequest { Id = id });
        }

        [HttpPost]
        public async Task<CreateInventoryCommandResponse> CreateProduct([FromBody] CreateInventoryCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<UpdateInventoryCommandResponse> UpdateProduct([FromForm] UpdateInventoryCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteInventoryCommandResponse> DeleteProduct(string id)
        {
            return await _mediator.Send(new DeleteInventoryCommandRequest { Id = id });
        }
        
        [HttpGet("search")]
        public async Task<IEnumerable<SearchInventoryQueryResponse>> SearchInventory([FromQuery] SearchInventoryQueryRequest request)
        {
            return await _mediator.Send(request);
        }
    }
}
