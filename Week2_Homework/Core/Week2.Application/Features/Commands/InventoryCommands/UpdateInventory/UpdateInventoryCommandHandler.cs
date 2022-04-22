using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.InventoryRepository;

namespace Week2.Application.Features.Commands.InventoryCommands.UpdateInventory
{

    public class UpdateInventoryCommandHandler : IRequestHandler<UpdateInventoryCommandRequest, UpdateInventoryCommandResponse>
    {
        private readonly IInventoryReadRepository _ınventoryReadRepository;
        private readonly IInventoryWriteRepository _ınventoryWriteRepository;

        public UpdateInventoryCommandHandler(IInventoryWriteRepository ınventoryWriteRepository, IInventoryReadRepository ınventoryReadRepository)
        {
            _ınventoryWriteRepository = ınventoryWriteRepository;
            _ınventoryReadRepository = ınventoryReadRepository;
        }

        public async Task<UpdateInventoryCommandResponse> Handle(UpdateInventoryCommandRequest request, CancellationToken cancellationToken)
        {
            var inventory =await _ınventoryReadRepository.GetByIdAsync(request.Id);

            if (inventory == null)
            {
                return new UpdateInventoryCommandResponse
                {
                    Success = false,
                    Message = "Inventory not found"
                };
            }

            inventory.Quantity = request.Quantity;
            _ınventoryWriteRepository.SaveAsync();

            return new UpdateInventoryCommandResponse
            {
                Success = true,
                Message = "Inventory updated"
            };
        }
    }

}
