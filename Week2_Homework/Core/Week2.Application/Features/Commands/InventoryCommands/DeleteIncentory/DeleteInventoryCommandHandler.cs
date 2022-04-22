using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Week2.Application.Repositories.InventoryRepository;

namespace Week2.Application.Features.Commands.InventoryCommands.DeleteIncentory
{

    public class DeleteInventoryCommandHandler : IRequestHandler<DeleteInventoryCommandRequest, DeleteInventoryCommandResponse>
    {
        private readonly IInventoryReadRepository _ınventoryReadRepository;
        private readonly IInventoryWriteRepository _ınventoryWriteRepository;

        public DeleteInventoryCommandHandler(IInventoryReadRepository ınventoryReadRepository, IInventoryWriteRepository ınventoryWriteRepository)
        {
            _ınventoryReadRepository = ınventoryReadRepository;
            _ınventoryWriteRepository = ınventoryWriteRepository;
        }

        public async Task<DeleteInventoryCommandResponse> Handle(DeleteInventoryCommandRequest request, System.Threading.CancellationToken cancellationToken)
        {
            if(request.Id is null)
            {
                return new DeleteInventoryCommandResponse
                {
                    Success = false,
                    Message = "Id is required"
                };
            }

            var p =await _ınventoryReadRepository.GetByIdAsync(request.Id);

            _ınventoryWriteRepository.Remove(p);
            await _ınventoryWriteRepository.SaveAsync();

            return new DeleteInventoryCommandResponse
            {
                Success = true,
                Message = "Successfully deleted inventory"
            };
        }
    }
}
