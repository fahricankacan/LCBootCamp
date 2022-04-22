using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.DiscountRepository;

namespace Week2.Application.Features.Queries.DiscountQueries.GetByIdDiscount
{

    public class GetByIdDiscountQueryHandler : IRequestHandler<GetByIdDiscountQueryRequest, GetByIdDiscountQueryResponse>
    {
        private readonly IDiscountReadRepository _discountReadRepository;
        private readonly IMapper _mapper;

        public GetByIdDiscountQueryHandler(IDiscountReadRepository _discountReadRepository, IMapper mapper)
        {
            _discountReadRepository = _discountReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdDiscountQueryResponse> Handle(GetByIdDiscountQueryRequest request, CancellationToken cancellationToken)
        {
            var discount =await _discountReadRepository.GetByIdAsync(request.Id);

            return _mapper.Map<GetByIdDiscountQueryResponse>(discount);
        }
    }
}
