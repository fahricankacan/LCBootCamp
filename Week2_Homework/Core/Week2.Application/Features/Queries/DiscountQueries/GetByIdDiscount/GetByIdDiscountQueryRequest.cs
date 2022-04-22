using MediatR;

namespace Week2.Application.Features.Queries.DiscountQueries.GetByIdDiscount
{
    public class GetByIdDiscountQueryRequest : IRequest<GetByIdDiscountQueryResponse> { public string Id { get; set; } }
}
//var discounts = await _discountReadRepository.GetAll().ToListAsync();

//return _mapper.Map<IEnumerable<GetAllDiscountQueryResponse>>(discounts);

//return discounts.Select(x => new GetAllDiscountQueryResponse
//{
//    Id = x.Id,
//    Name = x.Name,
//    Description = x.Description,
//    DiscountPercent = x.DiscountPercent,
//    IsActive = x.IsActive
//});