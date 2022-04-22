using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.ProductRepository;


namespace Week2.Application.Features.Queries.ProductQueries.GetByIdProduct
{

    public partial class GetByIdProductQuery : IRequestHandler<GetByIdProductQueryRequest, GetByIdProductQueryResponse>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IProductWriteRepository _productWriteRepository;


        public GetByIdProductQuery(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            _productReadRepository = productReadRepository;
            _productWriteRepository = productWriteRepository;
        }

        public async Task<GetByIdProductQueryResponse> Handle(GetByIdProductQueryRequest request, CancellationToken cancellationToken)
        {
            var product = await _productReadRepository.Table
               .Include(x => x.Category)
               .Include(x => x.Inventory)
               .Include(x => x.Discount)
               .FirstOrDefaultAsync(p => p.Id == Guid.Parse(request.Id));

            GetByIdProductQueryResponse response = new();
            response.Id = product.Id;
            response.Name = product.Name;
            response.Description = product.Description;
            response.Price = product.Price;
            response.CategoryName = product.Category.Name;
            response.Quantity = product.Inventory.Quantity;
            response.DiscountPersantange = product.Discount.DiscountPercent;
            response.TotalPrice = (product.Price*product.Discount.DiscountPercent)/100;

            return response;
       
        }
    }
}
