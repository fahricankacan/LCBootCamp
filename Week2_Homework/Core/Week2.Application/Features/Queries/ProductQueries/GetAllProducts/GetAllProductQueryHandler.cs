using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.ProductRepository;
using Week2.Domain.Entities;

namespace Week2.Application.Features.Queries.ProductQueries.GetAllProducts
{

    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQueryRequest, List<GetAllProductQueryResponse>>
    {
        private readonly IProductReadRepository _productReadRepository;

        public GetAllProductQueryHandler(IProductReadRepository productReadRepository)
        {
            _productReadRepository = productReadRepository;
        }

        public async Task<List<GetAllProductQueryResponse>> Handle(GetAllProductQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetAllProductQueryResponse> responseList = new();

            var products = await _productReadRepository.Table
                .Include(x => x.Category)
                .Include(x => x.Inventory)
                .Include(x => x.Discount).ToListAsync();

            foreach (var p in products)
            {
                responseList.Add(new GetAllProductQueryResponse
                {
                    
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    Quantity = p.Inventory.Quantity,
                    DiscountPersantange = p.Discount.DiscountPercent,
                    TotalPrice = CalculateTotalPrice(p.Price,p.Discount.DiscountPercent)

                });
            }
            return responseList;
        }
        private decimal CalculateTotalPrice(decimal price, decimal discountPersantange)
        {
            return price - ((price * discountPersantange)/100);
        }
    }
}
