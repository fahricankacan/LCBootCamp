using MediatR;

namespace Week2.Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductQueryRequest : IRequest<List<GetAllProductQueryResponse>>
    {

    }
}
