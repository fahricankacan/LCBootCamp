using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.InventoryRepository;

namespace Week2.Application.Features.Queries.InventoryQueries.GetByIdInventory
{

    public class GetByIdInventoryQueryHandler : IRequestHandler<GetByIdInventoryQueryRequest, GetByIdInventoryQueryResponse>
    {
        private readonly IInventoryReadRepository _ınventoryReadRepository;
        private readonly IMapper _mapper;
        
        public GetByIdInventoryQueryHandler(IInventoryReadRepository ınventoryReadRepository, IMapper mapper)
        {
            _ınventoryReadRepository = ınventoryReadRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdInventoryQueryResponse> Handle(GetByIdInventoryQueryRequest request, CancellationToken cancellationToken)
        {
            var inventory = await _ınventoryReadRepository.GetByIdAsync(request.Id);

            return _mapper.Map<GetByIdInventoryQueryResponse>(inventory);

            //return new GetByIdInventoryQueryResponse
            //{
            //    Id = inventory.Id,
            //    Quantity = inventory.Quantity
            //};
        }
    }
}
