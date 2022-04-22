using MediatR;

namespace Week2.Application.Features.Commands.InventoryCommands.CreateInventory
{
    public class CreateInventoryCommandRequest : IRequest<CreateInventoryCommandResponse>
    {
    
        public int Quantity { get; set; }
    }

}
