using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Week2.Application.Features.Commands.CategoryCommands.CreateCategory;
using Week2.Application.Features.Commands.CategoryCommands.DeleteCategory;
using Week2.Application.Features.Commands.CategoryCommands.UpdateCategory;
using Week2.Application.Features.Queries.CategoryQueries.GetAllCategories;
using Week2.Application.Features.Queries.CategoryQueries.GetByIdCategory;
using Week2.Application.Features.Queries.CategoryQueries.SearchQuery;

namespace Week2.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<List<GetAllCategoriesQueryResponse>> Get()
        {
            return (List<GetAllCategoriesQueryResponse>)await _mediator.Send(new GetAllCategoriesQueryRequest());
        }

        [HttpGet("{id}")]
        public async Task<GetByIdCategoryQueryResponse> GetById(string id)
        {
            return await _mediator.Send(new GetByIdCategoryQueryRequest { Id = id });
        }

        [HttpPost]
        public async Task<CreateCategoryCommandResponse> CreateProduct([FromBody] CreateCategoryCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpPut]
        public async Task<UpdateCategoryCommandResponse> UpdateProduct([FromForm] UpdateCategoryCommandRequest request)
        {
            return await _mediator.Send(request);
        }

        [HttpDelete("{id}")]
        public async Task<DeleteCategoryCommandResponse> DeleteProduct(string id)
        {
            return await _mediator.Send(new DeleteCategoryCommandRequest { Id = id });
        }

        [HttpGet("search")]
        public async Task<IEnumerable<SearchCategoryQueryResponse>> SearchCategoryQuery([FromQuery] SearchCategoryQueryRequest request)
        {
            return await _mediator.Send(request);
        }

    }
}
