using MediatR;

namespace Week2.Application.Features.Queries.InventoryQueries.SearchInventory
{
    public class SearchInventoryQueryRequest : IRequest<IEnumerable<SearchInventoryQueryResponse>>
    {
        public int QuantityRangerGreatNumber { get; set; }
        public int QuantityRangerLowNumber{ get; set; }
    }
}
