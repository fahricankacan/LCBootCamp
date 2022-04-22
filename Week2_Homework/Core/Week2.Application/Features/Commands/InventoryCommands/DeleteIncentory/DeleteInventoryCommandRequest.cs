using MediatR;

namespace Week2.Application.Features.Commands.InventoryCommands.DeleteIncentory
{
    public class DeleteInventoryCommandRequest : IRequest<DeleteInventoryCommandResponse> {
        public string Id { get; set; }
    }
}
