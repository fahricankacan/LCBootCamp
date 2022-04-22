using MediatR;

namespace Week2.Application.Features.Commands.DiscountCommands.CreateDiscount
{
    public class CreateDiscountCommandRequest : IRequest<CreateDiscountCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsActive { get; set; }
    }

}
