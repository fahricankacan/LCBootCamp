namespace Week2.Application.Features.Queries.ProductQueries.GetAllProducts
{
    public class GetAllProductQueryResponse
    {

        public Guid Id;
        public string Name { get; set; }
        public string Description { get; set; }
       
        public decimal Price { get; set; }
        public string CategoryName{ get; set; }
        public int Quantity { get; set; }
        public decimal DiscountPersantange { get; set; }
        public string? TotalPrice { get; set; }

        //public Guid Id { get; set; }
        //public decimal Price { get; set; }
        //public str Category{ get; set; }
        //public string Description { get; set; }
    }
}
