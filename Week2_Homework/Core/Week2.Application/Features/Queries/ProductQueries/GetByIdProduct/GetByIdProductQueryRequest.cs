using MediatR;


namespace Week2.Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQueryRequest : IRequest<GetByIdProductQueryResponse> { public string Id { get; set; } }
}
