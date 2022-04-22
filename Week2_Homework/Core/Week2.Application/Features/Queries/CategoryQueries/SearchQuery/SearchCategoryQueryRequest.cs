using MediatR;

namespace Week2.Application.Features.Queries.CategoryQueries.SearchQuery
{
    public class SearchCategoryQueryRequest : IRequest<IEnumerable<SearchCategoryQueryResponse>>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }


}
