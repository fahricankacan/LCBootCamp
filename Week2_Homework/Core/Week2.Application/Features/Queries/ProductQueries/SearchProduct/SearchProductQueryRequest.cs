using MediatR;

namespace Week2.Application.Features.Queries.ProductQueries.SearchProduct
{
    public class SearchProductQueryRequest : IRequest<IEnumerable<SearchProductQueryResponse>>
    {
        public string? Name { get; set; }      
        public decimal Price { get; set; }
    }
}
