using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.DiscountRepository;

namespace Week2.Application.Features.Queries.DiscountQueries.GetAllDiscounts
{

    public class GetAllDiscountsQueryHandler : IRequestHandler<GetAllDiscountsQueryRequest, IEnumerable<GetAllDiscountsQueryResponse>>
    {
        private readonly IDiscountReadRepository _discountReadRepository;
        private readonly IMapper _mapper;

        public GetAllDiscountsQueryHandler(IDiscountReadRepository _discountReadRepository, IMapper mapper, IDiscountReadRepository discountReadRepository)
        {
            _discountReadRepository = _discountReadRepository;
            _mapper = mapper;
            this._discountReadRepository = discountReadRepository;
        }

        public async Task<IEnumerable<GetAllDiscountsQueryResponse>> Handle(GetAllDiscountsQueryRequest request, CancellationToken cancellationToken)
        {
            var discounts = await _discountReadRepository.GetAll().ToListAsync();

            return _mapper.Map<IEnumerable<GetAllDiscountsQueryResponse>>(discounts);

            //return discounts.Select(x => new GetAllDiscountQueryResponse
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    DiscountPercent = x.DiscountPercent,
            //    IsActive = x.IsActive
            //});
        }
    }
}
