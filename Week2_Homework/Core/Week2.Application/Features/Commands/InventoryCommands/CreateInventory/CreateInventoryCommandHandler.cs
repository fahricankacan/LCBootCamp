using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.InventoryRepository;
using Week2.Domain.Entities;

namespace Week2.Application.Features.Commands.InventoryCommands.CreateInventory
{

    public class CreateInventoryCommandHandler : IRequestHandler<CreateInventoryCommandRequest, CreateInventoryCommandResponse>
    {
        private readonly IInventoryReadRepository _ınventoryReadRepository;
        private readonly IInventoryWriteRepository _ınventoryWriteRepository;

        public CreateInventoryCommandHandler( IInventoryWriteRepository ınventoryWriteRepository, IInventoryReadRepository ınventoryReadRepository)
        {
           
            _ınventoryWriteRepository = ınventoryWriteRepository;
            _ınventoryReadRepository = ınventoryReadRepository;
        }

        public async Task<CreateInventoryCommandResponse> Handle(CreateInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            var inventory = new Inventory
            {
                
                Quantity = request.Quantity
            };

            await _ınventoryWriteRepository.AddAsync(inventory);
            await _ınventoryWriteRepository.SaveAsync();

            return new CreateInventoryCommandResponse
            {
                Success = true,
                Message = "Inventory created successfully"
            };
        }
    }

}
