using MediatR;

namespace Week2.Application.Features.Queries.DiscountQueries.SearchDiscountQueryHandler
{
    public class SearchDiscountQueryRequest : IRequest<IEnumerable<SearchDiscountQueryResponse>>
    {
        public string? Name { get; set; }
        //public string Description { get; set; }
        //public decimal DiscountPercent { get; set; }
        public bool? IsActive { get; set; }
    }
}
