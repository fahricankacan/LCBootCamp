using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.ProductRepository;
using Week2.Domain.Entities;

namespace Week2.Application.Features.Queries.ProductQueries.SearchProduct
{
    public class SearchProductQueryHandler : IRequestHandler<SearchProductQueryRequest, IEnumerable<SearchProductQueryResponse>>
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly IMapper _mapper;

        public SearchProductQueryHandler( IMapper mapper, IProductReadRepository productReadRepository)
        {          
            _mapper = mapper;
            _productReadRepository = productReadRepository;
        }

        public async Task<IEnumerable<SearchProductQueryResponse>> Handle(SearchProductQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Product> discounts = _productReadRepository.Table;

            if (!string.IsNullOrEmpty(request.Name))
            {
                discounts = discounts.Where(x => x.Name.Contains(request.Name));
            }

            if (request.Price > 0)
            {
                discounts = discounts.Where(x => x.Price <= request.Price);
            }

            await discounts.ToListAsync();

            return _mapper.Map<IEnumerable<SearchProductQueryResponse>>(discounts);
        }  

    }
}
