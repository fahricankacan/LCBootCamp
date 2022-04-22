using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.InventoryRepository;

namespace Week2.Application.Features.Queries.InventoryQueries.GetAllInventories
{

    public class GetAllInventoriesQueryHandler : IRequestHandler<GetAllInventoriesQueryRequest, IEnumerable<GetAllInventoriesQueryResponse>>
    {
        private readonly IInventoryReadRepository _ınventoryReadRepository;
        private readonly IMapper _mapper;

        public GetAllInventoriesQueryHandler(IInventoryReadRepository ınventoryReadRepository, IMapper mapper)
        {
            _ınventoryReadRepository = ınventoryReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetAllInventoriesQueryResponse>> Handle(GetAllInventoriesQueryRequest request, CancellationToken cancellationToken)
        {
            var inventories = await _ınventoryReadRepository.GetAll().ToListAsync();

            return _mapper.Map<IEnumerable<GetAllInventoriesQueryResponse>>(inventories);

            //return inventories.Select(x => new GetAllInventoriesQueryResponse
            //{
            //    Id = x.Id,
            //    Quantity = x.Quantity
            //});

        }
    }
}
