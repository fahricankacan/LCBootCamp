using MediatR;

namespace Week2.Application.Features.Queries.CategoryQueries.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest : IRequest<GetByIdCategoryQueryResponse> { public string Id { get; set; } }
}
