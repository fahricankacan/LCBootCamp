using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.DiscountRepository;
using Week2.Domain.Entities;

namespace Week2.Application.Features.Queries.DiscountQueries.SearchDiscountQueryHandler
{
    public class SearchDiscountQueryHandler : IRequestHandler<SearchDiscountQueryRequest, IEnumerable<SearchDiscountQueryResponse>>
    {
        private readonly IDiscountReadRepository _discountReadRepository;
        private readonly IMapper _mapper;

        public SearchDiscountQueryHandler(IDiscountReadRepository discountReadRepository, IMapper mapper)
        {
            _discountReadRepository = discountReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SearchDiscountQueryResponse>> Handle(SearchDiscountQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Discount> discounts = _discountReadRepository.GetAll();

            if (!string.IsNullOrEmpty(request.Name))
            {
                discounts = discounts.Where(d => d.Name.Contains(request.Name));
            }

            //if (!string.IsNullOrEmpty(request.Description))
            //{
            //    discounts = discounts.Where(d => d.Description.Contains(request.Description));
            //}

            //if (request.DiscountPercent > 0)
            //{
            //    discounts = discounts.Where(d => d.DiscountPercent == request.DiscountPercent);
            //}

            if (request.IsActive == true || request.IsActive==false && request.IsActive !=null)
            {
                discounts = discounts.Where(d => d.IsActive == request.IsActive);
            }

                 var searchedList =   await discounts.ToListAsync();
                 var list = _mapper.Map<IEnumerable<SearchDiscountQueryResponse>>(searchedList);

            return list;
        }
    }
}
