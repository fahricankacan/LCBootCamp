using MediatR;

namespace Week2.Application.Features.Commands.DiscountCommands.UpadateDiscount
{
    public class UpdateDiscountCommandRequest : IRequest<UpdateDiscountCommandResponse> 
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsActive { get; set; }

    }

}
