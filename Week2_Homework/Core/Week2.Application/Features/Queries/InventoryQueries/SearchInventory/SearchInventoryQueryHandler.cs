using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.InventoryRepository;
using Week2.Domain.Entities;

namespace Week2.Application.Features.Queries.InventoryQueries.SearchInventory
{
    public class SearchInventoryQueryHandler : IRequestHandler<SearchInventoryQueryRequest, IEnumerable<SearchInventoryQueryResponse>>
    {
        private readonly IInventoryReadRepository _inventoryReadRepository;
        private readonly IMapper _mapper;

        public SearchInventoryQueryHandler(IInventoryReadRepository discountReadRepository, IMapper mapper)
        {
            _inventoryReadRepository = discountReadRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SearchInventoryQueryResponse>> Handle(SearchInventoryQueryRequest request, CancellationToken cancellationToken)
        {
            IQueryable<Inventory> inventories = _inventoryReadRepository.Table;

            if (request.QuantityRangerGreatNumber <= request.QuantityRangerLowNumber)
            {
                throw new InvalidOperationException("QuantityRangerGreatNumber can not be lower than QuantityRangerLowNumber.");
            }
            
            

            if (request.QuantityRangerGreatNumber >= 0 && request.QuantityRangerLowNumber >=0)
            {
                //discounts = discounts.Where(x=>x.Quantity >= request.QuantityRangerDown 
                //&& x.Quantity <= request.QuantityRangerDown);
                //discounts = discounts.Where(x => x.Quantity == request.Quantity);

                inventories = inventories.Where(x => x.Quantity >= request.QuantityRangerLowNumber && x.Quantity <= request.QuantityRangerGreatNumber);
            }

            await inventories.ToListAsync();

            return _mapper.Map<IEnumerable<SearchInventoryQueryResponse>>(inventories);

          
        }

        public class SearchInventoryQueryValidator : AbstractValidator<SearchInventoryQueryRequest>
        {
            public SearchInventoryQueryValidator()
            {
                RuleFor(x => x.QuantityRangerLowNumber).GreaterThanOrEqualTo(0).WithMessage("QuantityRangerLowNumber can not be lower than 0.");
                RuleFor(x => x.QuantityRangerGreatNumber).GreaterThanOrEqualTo(0).WithMessage("QuantityRangerLowNumber can not be lower than 0.");
            }
        }
    }
}
