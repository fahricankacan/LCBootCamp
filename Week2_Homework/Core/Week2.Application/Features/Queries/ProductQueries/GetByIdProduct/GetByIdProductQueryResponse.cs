namespace Week2.Application.Features.Queries.ProductQueries.GetByIdProduct
{
    public class GetByIdProductQueryResponse 
    {


        public Guid Id;
        public string Name { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }
        public string CategoryName { get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPersantange { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
