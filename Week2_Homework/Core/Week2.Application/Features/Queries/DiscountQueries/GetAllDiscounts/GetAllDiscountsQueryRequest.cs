using MediatR;

namespace Week2.Application.Features.Queries.DiscountQueries.GetAllDiscounts
{
    public class GetAllDiscountsQueryRequest : IRequest<IEnumerable<GetAllDiscountsQueryResponse>> { }
}
