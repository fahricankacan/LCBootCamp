using MediatR;

namespace Week2.Application.Features.Commands.InventoryCommands.UpdateInventory
{
    public class UpdateInventoryCommandRequest : IRequest<UpdateInventoryCommandResponse>
    {
        public string Id { get; set; }
        public int Quantity { get; set; }
    }

}
