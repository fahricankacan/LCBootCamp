using MediatR;

namespace Week2.Application.Features.Queries.InventoryQueries.GetByIdInventory
{
    public class GetByIdInventoryQueryRequest : IRequest<GetByIdInventoryQueryResponse> { public string Id { get; set; }}
}
