namespace Week2.Application.Features.Queries.DiscountQueries.GetAllDiscounts
{
    public class GetAllDiscountsQueryResponse 
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsActive { get; set; }
    }
}
