using MediatR;

namespace Week2.Application.Features.Queries.InventoryQueries.GetAllInventories
{
    public class GetAllInventoriesQueryRequest:IRequest<IEnumerable<GetAllInventoriesQueryResponse>> { }
}
