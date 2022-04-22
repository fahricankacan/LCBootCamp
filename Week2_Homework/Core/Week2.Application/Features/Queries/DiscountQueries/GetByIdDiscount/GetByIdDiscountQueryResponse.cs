namespace Week2.Application.Features.Queries.DiscountQueries.GetByIdDiscount
{
    public class GetByIdDiscountQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsActive { get; set; }
    }
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